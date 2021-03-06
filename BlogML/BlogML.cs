﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1.
// 

using System.Xml.Serialization;

namespace BlogML.Helper.BlogML {
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    [XmlRoot("blog", Namespace="http://www.blogml.com/2006/09/BlogML", IsNullable=false)]
    public partial class blogType {
        
        private titleType titleField;
        
        private titleType subtitleField;
        
        private authorsType authorsField;
        
        private extendedpropertyType[] extendedpropertiesField;
        
        private categoryType[] categoriesField;
        
        private postType[] postsField;
        
        private System.DateTime datecreatedField;
        
        private bool datecreatedFieldSpecified;
        
        private string rooturlField;
        
        /// <remarks/>
        public titleType title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        [XmlElement("sub-title")]
        public titleType subtitle {
            get {
                return this.subtitleField;
            }
            set {
                this.subtitleField = value;
            }
        }
        
        /// <remarks/>
        public authorsType authors {
            get {
                return this.authorsField;
            }
            set {
                this.authorsField = value;
            }
        }
        
        /// <remarks/>
        [XmlArray("extended-properties")]
        [XmlArrayItem("property", IsNullable=false)]
        public extendedpropertyType[] extendedproperties {
            get {
                return this.extendedpropertiesField;
            }
            set {
                this.extendedpropertiesField = value;
            }
        }
        
        /// <remarks/>
        [XmlArrayItem("category", IsNullable=false)]
        public categoryType[] categories {
            get {
                return this.categoriesField;
            }
            set {
                this.categoriesField = value;
            }
        }
        
        /// <remarks/>
        [XmlArrayItem("post", IsNullable=false)]
        public postType[] posts {
            get {
                return this.postsField;
            }
            set {
                this.postsField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute("date-created")]
        public System.DateTime datecreated {
            get {
                return this.datecreatedField;
            }
            set {
                this.datecreatedField = value;
            }
        }
        
        /// <remarks/>
        [XmlIgnore()]
        public bool datecreatedSpecified {
            get {
                return this.datecreatedFieldSpecified;
            }
            set {
                this.datecreatedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute("root-url")]
        public string rooturl {
            get {
                return this.rooturlField;
            }
            set {
                this.rooturlField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class titleType {
        
        private contentTypes typeField;
        
        private string[] textField;
        
        public titleType() {
            this.typeField = contentTypes.text;
        }
        
        /// <remarks/>
        [XmlAttribute()]
        [System.ComponentModel.DefaultValueAttribute(contentTypes.text)]
        public contentTypes type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [XmlText()]
        public string[] Text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public enum contentTypes {
        
        /// <remarks/>
        html,
        
        /// <remarks/>
        xhtml,
        
        /// <remarks/>
        text,
        
        /// <remarks/>
        base64,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class extendedpropertyType {
        
        private string nameField;
        
        private string valueField;
        
        /// <remarks/>
        [XmlAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class authorRefType {
        
        private string refField;
        
        /// <remarks/>
        [XmlAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class authorsRefType {
        
        private authorRefType authorField;
        
        /// <remarks/>
        public authorRefType author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class attachmentType {
        
        private bool embeddedField;
        
        private string mimetypeField;
        
        private double sizeField;
        
        private bool sizeFieldSpecified;
        
        private string externaluriField;
        
        private string urlField;
        
        private string valueField;
        
        /// <remarks/>
        [XmlAttribute()]
        public bool embedded {
            get {
                return this.embeddedField;
            }
            set {
                this.embeddedField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute("mime-type")]
        public string mimetype {
            get {
                return this.mimetypeField;
            }
            set {
                this.mimetypeField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public double size {
            get {
                return this.sizeField;
            }
            set {
                this.sizeField = value;
            }
        }
        
        /// <remarks/>
        [XmlIgnore()]
        public bool sizeSpecified {
            get {
                return this.sizeFieldSpecified;
            }
            set {
                this.sizeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute("external-uri")]
        public string externaluri {
            get {
                return this.externaluriField;
            }
            set {
                this.externaluriField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string url {
            get {
                return this.urlField;
            }
            set {
                this.urlField = value;
            }
        }
        
        /// <remarks/>
        [XmlText()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class categoryRefType {
        
        private string refField;
        
        /// <remarks/>
        [XmlAttribute()]
        public string @ref {
            get {
                return this.refField;
            }
            set {
                this.refField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class contentType {
        
        private contentTypes typeField;
        
        private string valueField;
        
        public contentType() {
            this.typeField = contentTypes.text;
        }
        
        /// <remarks/>
        [XmlAttribute()]
        [System.ComponentModel.DefaultValueAttribute(contentTypes.text)]
        public contentTypes type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [XmlText()]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [XmlInclude(typeof(authorType))]
    [XmlInclude(typeof(categoryType))]
    [XmlInclude(typeof(trackbackType))]
    [XmlInclude(typeof(commentType))]
    [XmlInclude(typeof(postType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class nodeType {
        
        private titleType titleField;
        
        private string idField;
        
        private System.DateTime datecreatedField;
        
        private bool datecreatedFieldSpecified;
        
        private System.DateTime datemodifiedField;
        
        private bool datemodifiedFieldSpecified;
        
        private bool approvedField;
        
        public nodeType() {
            this.approvedField = true;
        }
        
        /// <remarks/>
        public titleType title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute("date-created")]
        public System.DateTime datecreated {
            get {
                return this.datecreatedField;
            }
            set {
                this.datecreatedField = value;
            }
        }
        
        /// <remarks/>
        [XmlIgnore()]
        public bool datecreatedSpecified {
            get {
                return this.datecreatedFieldSpecified;
            }
            set {
                this.datecreatedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute("date-modified")]
        public System.DateTime datemodified {
            get {
                return this.datemodifiedField;
            }
            set {
                this.datemodifiedField = value;
            }
        }
        
        /// <remarks/>
        [XmlIgnore()]
        public bool datemodifiedSpecified {
            get {
                return this.datemodifiedFieldSpecified;
            }
            set {
                this.datemodifiedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool approved {
            get {
                return this.approvedField;
            }
            set {
                this.approvedField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class authorType : nodeType {
        
        private string emailField;
        
        /// <remarks/>
        [XmlAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class categoryType : nodeType {
        
        private string parentrefField;
        
        private string descriptionField;
        
        /// <remarks/>
        [XmlAttribute()]
        public string parentref {
            get {
                return this.parentrefField;
            }
            set {
                this.parentrefField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class trackbackType : nodeType {
        
        private string urlField;
        
        /// <remarks/>
        [XmlAttribute()]
        public string url {
            get {
                return this.urlField;
            }
            set {
                this.urlField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class commentType : nodeType {
        
        private contentType contentField;
        
        private string usernameField;
        
        private string useremailField;
        
        private string userurlField;
        
        /// <remarks/>
        public contentType content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute("user-name")]
        public string username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute("user-email")]
        public string useremail {
            get {
                return this.useremailField;
            }
            set {
                this.useremailField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute("user-url")]
        public string userurl {
            get {
                return this.userurlField;
            }
            set {
                this.userurlField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class postType : nodeType {
        
        private contentType contentField;
        
        private titleType postnameField;
        
        private contentType excerptField;
        
        private categoryRefType[] categoriesField;
        
        private commentType[] commentsField;
        
        private trackbackType[] trackbacksField;
        
        private attachmentType[] attachmentsField;
        
        private authorsRefType authorsField;
        
        private string posturlField;
        
        private blogpostTypes typeField;
        
        private bool typeFieldSpecified;
        
        private bool hasexcerptField;
        
        private bool hasexcerptFieldSpecified;
        
        private string viewsField;
        
        /// <remarks/>
        public contentType content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
            }
        }
        
        /// <remarks/>
        [XmlElement("post-name")]
        public titleType postname {
            get {
                return this.postnameField;
            }
            set {
                this.postnameField = value;
            }
        }
        
        /// <remarks/>
        public contentType excerpt {
            get {
                return this.excerptField;
            }
            set {
                this.excerptField = value;
            }
        }
        
        /// <remarks/>
        [XmlArrayItem("category", IsNullable=false)]
        public categoryRefType[] categories {
            get {
                return this.categoriesField;
            }
            set {
                this.categoriesField = value;
            }
        }
        
        /// <remarks/>
        [XmlArrayItem("comment", IsNullable=false)]
        public commentType[] comments {
            get {
                return this.commentsField;
            }
            set {
                this.commentsField = value;
            }
        }
        
        /// <remarks/>
        [XmlArrayItem("trackback", IsNullable=false)]
        public trackbackType[] trackbacks {
            get {
                return this.trackbacksField;
            }
            set {
                this.trackbacksField = value;
            }
        }
        
        /// <remarks/>
        [XmlArrayItem("attachment", IsNullable=false)]
        public attachmentType[] attachments {
            get {
                return this.attachmentsField;
            }
            set {
                this.attachmentsField = value;
            }
        }
        
        /// <remarks/>
        public authorsRefType authors {
            get {
                return this.authorsField;
            }
            set {
                this.authorsField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute("post-url")]
        public string posturl {
            get {
                return this.posturlField;
            }
            set {
                this.posturlField = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public blogpostTypes type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [XmlIgnore()]
        public bool typeSpecified {
            get {
                return this.typeFieldSpecified;
            }
            set {
                this.typeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public bool hasexcerpt {
            get {
                return this.hasexcerptField;
            }
            set {
                this.hasexcerptField = value;
            }
        }
        
        /// <remarks/>
        [XmlIgnore()]
        public bool hasexcerptSpecified {
            get {
                return this.hasexcerptFieldSpecified;
            }
            set {
                this.hasexcerptFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [XmlAttribute()]
        public string views {
            get {
                return this.viewsField;
            }
            set {
                this.viewsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public enum blogpostTypes {
        
        /// <remarks/>
        normal,
        
        /// <remarks/>
        article,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(Namespace="http://www.blogml.com/2006/09/BlogML")]
    public partial class authorsType {
        
        private authorType authorField;
        
        /// <remarks/>
        public authorType author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
            }
        }
    }
}
