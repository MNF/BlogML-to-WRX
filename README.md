# BlogML-to-WRX
The tool can be used if you need to convert BlogML format into WRX file (WordPress Extended RSS import file format) for subsequent import it into WordPress.

The tool was originally developed by Saravana Kumar and initial code was downloaded from blog ["Migrating your blog from any BlogML based platform to WordPress"](http://blogs.biztalk360.com/migrating-your-blog-from-any-blogml-based-platform-to-wordpress-2/)

The code in this repository has error handling/logging enhancements and fixed import of multiple comments.


For detailed description see the blog post ["Migrating your blog from any BlogML based platform to WordPress"](http://blogs.biztalk360.com/migrating-your-blog-from-any-blogml-based-platform-to-wordpress-2/)

### Extract from the post:

Options available with the tool.  
  * RemoveComments  
  * ExportToWRX  
  * QATarget  
  * QASource  
  * NewWRXWithOnlyFailedPosts  

You simply run the tool with the following command

BlogML.Helper.exe /Action:ExportToWRX /BlogMLFile:BlogML.xml /SourceUrl:geekswithblogs.net/OldBlog /TargetUrl:NewBlog.wordpress.com

### Similar tools :
To import blogML format to Wordpress, there are a few tools available.  
If your new site is self hosted from Wordpress.org, you can install some of available plugins, e.g. [importing-a-big-honkin-blogml-xml-file-into-wordpress](http://nixmash.com/on-wordpress/importing-a-big-honkin-blogml-xml-file-into-wordpress/)
But custom plugins not supported in Wordpress.com. For Wordpress.com you can use 
[Blogmigrator](https://github.com/Dillie-O/blogmigrator ) or this tool(aka BlogML.Helper.exe).
Blogmigrator has less steps to do, but doesn't import comments. If comments are important to you, the only choice that I found is this tool.

## WordPress and high post ID's when using DasBlog as a Source
Depending on which Blog Platform you are migrating from. The postid field is sometimes a GUID, this is usually the case with DasBlog. This can cause issues in the WordPress WRX Importer plugin. It tries to convert the GUIDs to integers but it does this in quite an odd way. If you have quite a few posts in the blog you are migrating it will eventually go past 2147483647 as a postid. This is fine in MySQL but not in WordPress where it attempts to convert postid's when you render posts in WordPress to an int. When PHP encounters a post id higher than 2147483647 when converting to int it just makes the post id 2147483647 and you will end up with what looks like multiple duplicates but what is happening is all blogposts with an id greater than 2147483647 will appear as the post that actually has that id in WordPress. 

To get around this use the **BlogPostIdSeed**, first check what the highest postid is in your WordPress if you have existing posts. If you have a new site you should be good with a number around 50. This will replace all the postids in the generated files with an incremented number starting from the seed.

BlogML.Helper.exe /Action:ExportToWRX /BlogMLFile:sourceblogML.xml /SourceUrl:myblog.com /TargetUrl:mynewblog.com /BlogPostIdSeed:50
