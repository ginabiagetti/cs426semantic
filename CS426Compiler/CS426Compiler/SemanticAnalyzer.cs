using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS426Compiler
{
    class SemanticAnalyzer : comp5210.analysis.DepthFirstAdapter
    {
        System.Collections.Generic.Dictionary<string, CS426Compiler.Definition>
           stringhash = new Dictionary<string, Definition>();
        System.Collections.Generic.Dictionary<comp5210.node.Node, CS426Compiler.Definition>
            nodehash = new Dictionary<comp5210.node.Node, Definition>();
       
        public override void InAProgram(comp5210.node.AProgram node)
        {
            BasicType inttype = new BasicType();
            inttype.name = "int";
            BasicType flttype = new BasicType();
            flttype.name = "float";
            stringhash.Add(inttype.name, inttype);
            stringhash.Add(flttype.name, flttype);

            base.InAProgram(node);
        }

        
    }
}
