using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmToolkitTemplate {
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class EnumTextAttribute : Attribute {
        public EnumTextAttribute(string text) {
            this.Text = text;
        }
        public string Text {
            get;
            private set;
        }
    }

}
