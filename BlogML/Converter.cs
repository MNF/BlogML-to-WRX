using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BlogML.Helper.BlogML
{
    class BlogMLToWRXConverter
    {
        internal static string GenerateWRXFile(string blogMLFilePath)
        {
            if (string.IsNullOrEmpty(blogMLFilePath))
                throw new ArgumentNullException("blogMLFilePath", "BlogMLFilePath is mandatory parameter");

            string wrxFileName = string.Format("{0}.WRX.xml", Path.GetFileNameWithoutExtension(blogMLFilePath));

            BlogML.blogType blogML = SerializeBlogML(blogMLFilePath);
            WriteWXRDocument(blogML, string.Empty, wrxFileName);

            return wrxFileName;

        }

        internal static void GenerateHelperFiles(string sourceBaseUrl, string targetBaseurl, string wrxFilePath)
        {

            if (string.IsNullOrEmpty(sourceBaseUrl))
                throw new ArgumentNullException("sourceBaseUrl", "Source Base URL is mandatory parameter");
            if (string.IsNullOrEmpty(targetBaseurl))
                throw new ArgumentNullException("targetBaseurl", "Target Base URL is mandatory parameter");
            if (string.IsNullOrEmpty(wrxFilePath))
                throw new ArgumentNullException("wrxFilePath", "WRX File Path is mandatory parameter");


            //Delete files if already exists
            string redirectFilePath = string.Format("{0}.Redirect.txt", Path.GetFileNameWithoutExtension(wrxFilePath));
            string sourceQAFilePath = string.Format("{0}.SourceQA.txt", Path.GetFileNameWithoutExtension(wrxFilePath));
            string targetQAFilePath = string.Format("{0}.TargetQA.txt", Path.GetFileNameWithoutExtension(wrxFilePath));


            if (File.Exists(redirectFilePath))
                File.Delete(redirectFilePath);

            if (File.Exists(sourceQAFilePath))
                File.Delete(sourceQAFilePath);

            if (File.Exists(targetQAFilePath))
                File.Delete(targetQAFilePath);

            StreamWriter swRedirect = File.CreateText(redirectFilePath);
            StreamWriter swSourceQA = File.CreateText(sourceQAFilePath);
            StreamWriter swTargetQA = File.CreateText(targetQAFilePath);


            //Redirect File
            //string s = "RewriteRule ^/saravana/post/2011/05/03/Introduction-to-BizTalk-360.aspx$ http://blog.biztalk360.com/post/2011/05/03/Introduction-to-BizTalk-360.aspx [R=301, NC, L]";
            string redirectFormat = "RewriteRule ^{0}$ http://{1}/{2} [R=301, NC, L]";
            string sourceQAFormat = "http://{0}{1}";
            string targetQAFormat = "http://{0}/{1}";

            XDocument xd = XDocument.Load(wrxFilePath);
            XNamespace wp = "http://wordpress.org/export/1.0/";
            var posts = from c in xd.Descendants("item")
                        select c;

            foreach (var post in posts)
            {
                string link = post.Element("link").Value;
                string postName = post.Element(wp + "post_name").Value;

                string r = string.Format(redirectFormat, link, targetBaseurl, postName);
                swRedirect.WriteLine(r);

                string s = string.Format(sourceQAFormat, sourceBaseUrl, link);
                swSourceQA.WriteLine(s);

                string t = string.Format(targetQAFormat, targetBaseurl, postName);
                swTargetQA.WriteLine(t);

            }

            //Close all streams
            swRedirect.Close();
            swSourceQA.Close();
            swTargetQA.Close();
        }

        internal static string GenerateWRXFileWithFailedPosts(string wrxFileName, string qaReportFileName)
        {
            //Add all the failed post names to List<string>
            List<string> lines = File.ReadAllLines(qaReportFileName).ToList();
            List<string> errorPostNames = new List<string>();
            foreach (string line in lines)
            {
                string status = line.Split(',')[0];
                string url = line.Split(',')[1];

                if (status != "OK")
                {
                    string[] urlsplit = url.Split('/');
                    string postname = urlsplit[urlsplit.Length - 1];

                    errorPostNames.Add(postname);
                }
            }

            XDocument xd = XDocument.Load(wrxFileName);
            XNamespace wp = "http://wordpress.org/export/1.0/";


            var posts = (from c in xd.Descendants("item")
                        select c).ToList();

            foreach (var post in posts)
            {
                var element = post.Element(wp + "post_name");
                if (element != null)
                {
                    string postname = element.Value;

                    var r = from s in errorPostNames
                            where s == postname
                            select s;

                    if(!r.Any())
                        post.Remove();
                }
            }


            string wrxNewFileName = string.Format("{0}.OnlyFailed.xml", Path.GetFileNameWithoutExtension(wrxFileName));
            xd.Save(wrxNewFileName);

            return wrxNewFileName;
        }

        private static BlogML.blogType SerializeBlogML(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BlogML.blogType));

            TextReader reader = new StreamReader(fileName);
            BlogML.blogType blogData = (BlogML.blogType)serializer.Deserialize(reader);
            reader.Close();

            return blogData;
        }

        private static void WriteWXRDocument(BlogML.blogType blogData, string baseUrl, string fileName)
        {
            BlogML.categoryType currCategory;
            BlogML.categoryRefType currCatRef;
            string categoryName;
            BlogML.commentType currComment;
            BlogML.postType currPost;
            XmlTextWriter writer = new XmlTextWriter(fileName, new UTF8Encoding(false));
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();
            writer.WriteStartElement("rss");
            writer.WriteAttributeString("version", "2.0");
            writer.WriteAttributeString("xmlns", "content", null, "http://purl.org/rss/1.0/modules/content/");
            writer.WriteAttributeString("xmlns", "wfw", null, "http://wellformedweb.org/CommentAPI/");
            writer.WriteAttributeString("xmlns", "dc", null, "http://purl.org/dc/elements/1.1/");
            writer.WriteAttributeString("xmlns", "wp", null, "http://wordpress.org/export/1.0/");

            // Write Blog Info.
            writer.WriteStartElement("channel");
            writer.WriteElementString("title", String.Join(" ", blogData.title.Text));
            writer.WriteElementString("link", baseUrl + blogData.rooturl);
            writer.WriteElementString("description", "Exported Blog");
            writer.WriteElementString("pubDate", blogData.datecreated.ToString("ddd, dd MMM yyyy HH:mm:ss +0000"));
            writer.WriteElementString("generator", "http://wordpress.org/?v=MU");
            writer.WriteElementString("language", "en");
            writer.WriteElementString("wp:wxr_version", "1.0");
            writer.WriteElementString("wp:base_site_url", blogData.rooturl);
            writer.WriteElementString("wp:base_blog_url", blogData.rooturl);

            // Create tags (currently not in use with BlogML document)
            //for(int i = 0; i <= tagCount - 1; i++)
            //{
            //    writer.WriteStartElement("wp:tag");
            //    writer.WriteElementString("wp:tag_slug", tags[0].ToString().Replace(' ', '-'));
            //    writer.WriteStartElement("wp:tag_name");
            //    writer.WriteCData(tags[0].ToString());
            //    writer.WriteEndElement(); // wp:tag_name
            //    writer.WriteEndElement(); // sp:tag
            //}

            // Create categories
            if (blogData.categories != null)
            {
                for (int i = 0; i <= blogData.categories.Length - 1; i++)
                {
                    currCategory = blogData.categories[i];
                    writer.WriteStartElement("wp:category");
                    writer.WriteElementString("wp:category_nicename", string.Join(" ", currCategory.title.Text).ToLower().Replace(' ', '-'));
                    writer.WriteElementString("wp:category_parent", "");
                    writer.WriteStartElement("wp:cat_name");
                    writer.WriteCData(string.Join(" ", currCategory.title.Text));
                    writer.WriteEndElement(); // wp:cat_name
                    writer.WriteEndElement(); // wp:category
                }
            }

            // TODO: Swap code so that all posts are processed, not just first 5.
            for (int i = 0; i <= blogData.posts.Length - 1; i++)
            {
                currPost = blogData.posts[i];


                writer.WriteStartElement("item");
                writer.WriteElementString("title", string.Join(" ", currPost.title.Text));
                writer.WriteElementString("link", baseUrl + currPost.posturl);
                writer.WriteElementString("pubDate", currPost.datecreated.ToString("ddd, dd MMM yyyy HH:mm:ss +0000"));
                writer.WriteStartElement("dc:creator");
                writer.WriteCData(String.Join(" ", blogData.authors.author.title.Text));
                writer.WriteEndElement(); // dc:creator

                // Post Tags/Categories (currently only categories are implemented with BlogML
                if (currPost.categories != null)
                {
                    for (int j = 0; j <= currPost.categories.Length - 1; j++)
                    {
                        currCatRef = currPost.categories[j];
                        categoryName = GetCategoryById(blogData, currCatRef.@ref);
                        writer.WriteStartElement("category");
                        writer.WriteCData(categoryName);
                        writer.WriteEndElement(); // category
                        writer.WriteStartElement("category");
                        writer.WriteAttributeString("domain", "category");
                        writer.WriteAttributeString("nicename", categoryName.ToLower().Replace(' ', '-'));
                        writer.WriteCData(categoryName);
                        writer.WriteEndElement(); // category domain=category
                    }
                }

                writer.WriteStartElement("guid");
                writer.WriteAttributeString("isPermaLink", "false");
                writer.WriteString(" ");
                writer.WriteEndElement(); // guid
                writer.WriteElementString("description", ".");
                writer.WriteStartElement("content:encoded");
                writer.WriteCData(currPost.content.Value);
                writer.WriteEndElement(); // content:encoded
                writer.WriteElementString("wp:post_id", currPost.id);
                writer.WriteElementString("wp:post_date", currPost.datecreated.ToString("yyyy-MM-dd HH:mm:ss"));
                writer.WriteElementString("wp:post_date_gmt", currPost.datecreated.ToString("yyyy-MM-dd HH:mm:ss"));
                writer.WriteElementString("wp:comment_status", "open");
                writer.WriteElementString("wp:ping_status", "open");
                writer.WriteElementString("wp:post_name", SafeUrl(string.Join(" ", currPost.title.Text)));
                writer.WriteElementString("wp:status", "publish");
                writer.WriteElementString("wp:post_parent", "0");
                writer.WriteElementString("wp:menu_order", "0");
                writer.WriteElementString("wp:post_type", "post");
                //writer.WriteStartElement("wp:post_password");
                //writer.WriteString(" ");
                //writer.WriteEndElement(); // wp:post_password

                if (currPost.comments != null)
                {
                    for (int k = 0; k <= currPost.comments.Length - 1; k++)
                    {
                        currComment = currPost.comments[k];
                        writer.WriteStartElement("wp:comment");
                        writer.WriteElementString("wp:comment_date", currComment.datecreated.ToString("yyyy-MM-dd HH:mm:ss"));
                        writer.WriteElementString("wp:comment_date_gmt", currComment.datecreated.ToString("yyyy-MM-dd HH:mm:ss"));
                        writer.WriteStartElement("wp:comment_author");
                        if ((!String.IsNullOrEmpty(currComment.useremail)) || (currComment.useremail != "http://"))
                        {
                            writer.WriteCData(currComment.username);
                        }
                        else
                        {
                            writer.WriteCData("Nobody");
                        }
                        writer.WriteEndElement(); // wp:comment_author
                        writer.WriteElementString("wp:comment_author_email", currComment.useremail);
                        writer.WriteElementString("wp:comment_author_url", currComment.userurl);
                        writer.WriteElementString("wp:comment_type", " ");
                        writer.WriteStartElement("wp:comment_content");
                        writer.WriteCData(currComment.content.Value);
                        writer.WriteEndElement(); // wp:comment_content

                        if (currComment.approved)
                        {
                            writer.WriteElementString("wp:comment_approved", null, "1");
                        }
                        else
                        {
                            writer.WriteElementString("wp:comment_approved", null, "0");
                        }

                        writer.WriteElementString("wp", "comment_parent", null, "0");
                        writer.WriteEndElement(); // wp:comment
                    }
                }

                writer.WriteEndElement(); // item
            }

            writer.WriteEndElement(); // channel
            writer.WriteEndElement(); // rss

            writer.Flush();
            writer.Close();
        }

        private static string GetCategoryById(BlogML.blogType BlogData, string CategoryId)
        {
            string results = "none";

            for (int i = 0; i <= BlogData.categories.Length - 1; i++)
            {
                if (BlogData.categories[i].id == CategoryId)
                {
                    results = String.Join(" ", BlogData.categories[i].title.Text);
                    break;
                }
            }

            return results;
        }
        private static string SafeUrl(string url)
        {
            //convert to lowr
            url = url.ToLower();

            //replace space
            const string pattern = "[^a-zA-Z0-9]+"; //regex pattern 
            string result = System.Text.RegularExpressions.Regex.Replace(url, pattern, "-");

            return result;
        }
    }
}
