# BlogML-to-WRX
The tool can be used if you need to convert BlogML format into WRX file (WordPress Extended RSS import file format) for subsequent import it into WordPress.

The tool was originally developed by Saravana Kumar and initial code was downloaded from blog ["Migrating your blog from any BlogML based platform to WordPress"](http://blogs.biztalk360.com/migrating-your-blog-from-any-blogml-based-platform-to-wordpress-2/)

The code in this repository has error handling/logging enhancements and fixed import of multiple comments.


For detailed description see the blog post ["Migrating your blog from any BlogML based platform to WordPress"](http://blogs.biztalk360.com/migrating-your-blog-from-any-blogml-based-platform-to-wordpress-2/)

###Extract from the post:

Options available with the tool.  
  * RemoveComments  
  * ExportToWRX  
  * QATarget  
  * QASource  
  * NewWRXWithOnlyFailedPosts  

You simply run the tool with the following command

BlogML.Helper.exe /Action:ExportToWRX /BlogMLFile:BlogML.xml /SourceUrl:geekswithblogs.net/OldBlog /TargetUrl:NewBlog.wordpress.com

###Similar tools :
To import blogML format to Wordpress, there are a few tools available.  
If your new site is self hosted from Wordpress.org, you can install some of available plugins, e.g. [importing-a-big-honkin-blogml-xml-file-into-wordpress](http://nixmash.com/on-wordpress/importing-a-big-honkin-blogml-xml-file-into-wordpress/)
But custom plugins not supported in Wordpress.com. For Wordpress.com you can use 
[Blogmigrator](https://github.com/Dillie-O/blogmigrator ) or this tool(aka BlogML.Helper.exe).
Blogmigrator has less steps to do, but doesn't import comments. If comments are important to you, the only choice that I found is this tool.
