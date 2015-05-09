using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladkih.Nsudotnet.LinesCounter
{
    class CommentsTemplate
    {
        public string MonoComment { get; private set; }
        public string StartMultylineComment { get; private set; }
        public string EndMultylineComment { get; private set; }

        public CommentsTemplate
            (string monoComment = "//", 
            string startMultyLineComment = "/*", 
            string endMultyLineComment = "*/")
        {
            MonoComment = monoComment;
            StartMultylineComment = startMultyLineComment;
            EndMultylineComment = endMultyLineComment;
        }
    }
}
