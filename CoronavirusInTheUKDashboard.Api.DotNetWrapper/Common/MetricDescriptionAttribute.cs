using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common
{
    /// <summary>
    /// Attribute describing a dashboard metric
    /// </summary>
    public class MetricDescriptionAttribute : DescriptionAttribute
    {

        /// <devdoc>
        /// <para>Specifies the default value for the <see cref='System.ComponentModel.DescriptionAttribute'/> , which is an
        ///    empty string (""). This <see langword='static'/> field is read-only.</para>
        /// </devdoc>
        public static readonly MetricDescriptionAttribute Default = new MetricDescriptionAttribute();

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public MetricDescriptionAttribute() : this(string.Empty, string.Empty, string.Empty)
        {
        }

        /// <devdoc>
        ///    <para>Initializes a new instance of the <see cref='CoronavirusInTheUKDashboard.Api.DotNetWrapper.Common.MetricDescriptionAttribute'/> class.</para>
        /// </devdoc>
        public MetricDescriptionAttribute(string description, string longDescription, string link) : base(description)
        {
            this.LongDescriptionValue = longDescription;
            this.LinkValue = link;
        }

        /// <devdoc>
        ///    <para>Gets the long description stored in this attribute.</para>
        /// </devdoc>
        public virtual string LongDescription
        {
            get
            {
                return LongDescriptionValue;
            }
        } 

        /// <devdoc>
        ///    <para>Gets the link stored in this attribute.</para>
        /// </devdoc>
        public virtual string Link
        {
            get
            {
                return LinkValue;
            }
        }

        /// <devdoc>
        ///     Read/Write property that directly modifies the string stored
        ///     in the Long Description  attribute. The default implementation
        ///     of the Description property simply returns this value.
        /// </devdoc>
        protected string LongDescriptionValue { get; set; }


        /// <devdoc>
        ///     Read/Write property that directly modifies the string stored
        ///     in the Link attribute. The default implementation
        ///     of the Description property simply returns this value.
        /// </devdoc>
        protected string LinkValue { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            MetricDescriptionAttribute other = obj as MetricDescriptionAttribute;

            return (other != null) && other.Description == Description && other.LongDescription == LongDescription && other.Link == Link;
        }

        public override int GetHashCode()
        {
            return (Description + LongDescription + Link).GetHashCode();
        }

    }
}
