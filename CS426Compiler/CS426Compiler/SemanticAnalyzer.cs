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

            
        }

        public override void OutAIntDeclareConstantDeclare(comp5210.node.AIntDeclareConstantDeclare node)
        {
            string type = node.GetType().Text;
            string name = node.GetName().Text;
             Definition typedefn;
            // lookup the type
            if (!stringhash.TryGetValue(type, out typedefn))
            {
                Console.WriteLine("[" + node.GetType().Line + "]: " +
                    type + " is not defined.");
            }
            // check to make sure the type is an int
            else if (type != "int")
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    "Type mismatch, should be an int");
            }
            else
            {
                // add this variable to the hash table if
                // variable name isn't already defined.
                VariableDefinition vardefn = new VariableDefinition();
                vardefn.name = name;
                vardefn.vartype = typedefn as TypeDefinition;
                if (stringhash.ContainsKey(name))
                {//if the string is already in the stringhash, don't add it and return an error
                    Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    name + " has already been declared.");
                }
                else
                {//if not, then add it to the hash!
                    stringhash.Add(vardefn.name, vardefn);
                    Console.WriteLine("added " + name + " of type " + type + " to the stringhash");
                }

            }
            
        }
      
        public override void OutAFloatDelcareConstantDeclare(comp5210.node.AFloatDelcareConstantDeclare node)
        {
            string type = node.GetType().Text;
            string name = node.GetName().Text;
            Definition typedefn;
            // lookup the type
            if (!stringhash.TryGetValue(type, out typedefn))
            {
                Console.WriteLine("[" + node.GetType().Line + "]: " +
                    type + " is not defined.");
            }
            // check to make sure the type is an int
            else if (type != "float")
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    "Type mismatch, should be an float");
            }
            else
            {
                // add this variable to the hash table if
                // variable name isn't already defined.
                VariableDefinition vardefn = new VariableDefinition();
                vardefn.name = name;
                vardefn.vartype = typedefn as TypeDefinition;
                if (stringhash.ContainsKey(name))
                {//if the string is already in the stringhash, don't add it and return an error
                    Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    name + " has already been declared.");
                }
                else
                {//if not, then add it to the hash!
                    stringhash.Add(vardefn.name, vardefn);
                    Console.WriteLine("added " + name + " of type " + type + " to the stringhash");
                }
                
            }
            
        }
        public override void InAVarDeclare(comp5210.node.AVarDeclare node)
        {
           
            base.InAVarDeclare(node);
        }
        public override void OutAVarDeclare(comp5210.node.AVarDeclare node)
        {
            string type = node.GetType().Text;
            string name = node.GetName().Text;
            Definition typedefn;
            // lookup the type
            if (!stringhash.TryGetValue(type, out typedefn))
            {
                Console.WriteLine("[" + node.GetType().Line + "]: " +
                    type + " is not defined.");
            }
            // check to make sure what we got back is a type
            else if (!(typedefn is TypeDefinition))
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    type + " is an invalid type.");
            }
            else
            {
                // add this variable to the hash table if
                // variable name isn't already defined.
                VariableDefinition vardefn = new VariableDefinition();
                vardefn.name = name;
                vardefn.vartype = typedefn as TypeDefinition;
                if (stringhash.ContainsKey(name)){//if the string is already in the stringhash, don't add it and return an error
                    Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    name + " has already been declared.");
                }else{//if not, then add it to the hash!
                    stringhash.Add(vardefn.name, vardefn);
                    Console.WriteLine("added " + name + " of type " +type+ " to the stringhash");
                }
                
            }
       }
        public override void OutAIfStatement(comp5210.node.AIfStatement node)
        {
            base.OutAIfStatement(node);
        }
        public override void OutAWhileLoop(comp5210.node.AWhileLoop node)
        {
            base.OutAWhileLoop(node);
        }


        public override void OutAExpressionAssignStatement(comp5210.node.AExpressionAssignStatement node)
        {
            /*
            string name = node.GetId().Text;
           


            // add this variable to the hash table if
            // variable name isn't already defined.

            {
                VariableDefinition vardefn = new VariableDefinition();
                vardefn.name = name;

                if (stringhash.ContainsKey(name))
                {
                    stringhash.Add(vardefn.name, vardefn);
                    Console.WriteLine("added " + name + " to the stringhash");


                }
            }*/
        }
        public override void OutAArrayAssignStatement(comp5210.node.AArrayAssignStatement node)
        {
            base.OutAArrayAssignStatement(node);
            
        }
        public override void OutAArrayDeclare(comp5210.node.AArrayDeclare node)
        {
            string type = node.GetType().Text;
            string name = node.GetName().Text;
            Definition typedefn;
            // lookup the type
            if (!stringhash.TryGetValue(type, out typedefn))
            {
                Console.WriteLine("[" + node.GetType().Line + "]: " +
                    type + " is not defined.");
            }
            // check to make sure what we got back is a type
            else if (!(typedefn is TypeDefinition))
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    type + " is an invalid type.");
            }
            else
            {
                // add this variable to the hash table if
                // variable name isn't already defined.
                VariableDefinition vardefn = new VariableDefinition();
                vardefn.name = name;
                vardefn.vartype = typedefn as TypeDefinition;
                if (stringhash.ContainsKey(name))
                {//if the string is already in the stringhash, don't add it and return an error
                    Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    name + " has already been declared.");
                }
                else
                {//if not, then add it to the hash!
                    stringhash.Add(vardefn.name, vardefn);
                    Console.WriteLine("added " + name + " of type " + type + " to the stringhash");
                }

            }
            
        }
        public override void OutAMoreFormalParameters(comp5210.node.AMoreFormalParameters node)
        {
            base.OutAMoreFormalParameters(node);
        }
        public override void OutALastFormalParameters(comp5210.node.ALastFormalParameters node)
        {
            base.OutALastFormalParameters(node);
        }
        public override void OutAMoreActualParameters(comp5210.node.AMoreActualParameters node)
        {
            base.OutAMoreActualParameters(node);
        }
        public override void OutALastActualParameters(comp5210.node.ALastActualParameters node)
        {
            base.OutALastActualParameters(node);
        }
       
        
        public override void OutAStartExp(comp5210.node.AStartExp node)
        {
            base.OutAStartExp(node);
        }
        public override void OutAAndExp(comp5210.node.AAndExp node)
        {
            base.OutAAndExp(node);
        }
        public override void OutANotEqualExp(comp5210.node.ANotEqualExp node)
        {
            base.OutANotEqualExp(node);
        }
        public override void OutAEqualToExp(comp5210.node.AEqualToExp node)
        {
            base.OutAEqualToExp(node);
        }
        public override void OutANextExp(comp5210.node.ANextExp node)
        {
            base.OutANextExp(node);
        }
        
        
        public override void OutAGreaterThanComparators(comp5210.node.AGreaterThanComparators node)
        {
            base.OutAGreaterThanComparators(node);
        }
        public override void OutALessThanComparators(comp5210.node.ALessThanComparators node)
        {
            base.OutALessThanComparators(node);
        }
        public override void OutAGreaterEqualComparators(comp5210.node.AGreaterEqualComparators node)
        {
            base.OutAGreaterEqualComparators(node);
        }
        public override void OutALessEqualComparators(comp5210.node.ALessEqualComparators node)
        {
            base.OutALessEqualComparators(node);
        }
        public override void OutANextComparators(comp5210.node.ANextComparators node)
        {
            base.OutANextComparators(node);
        }
        
        
        public override void OutASubtractMath1(comp5210.node.ASubtractMath1 node)
        {
            base.OutASubtractMath1(node);
        }
        public override void OutAAddMath1(comp5210.node.AAddMath1 node)
        {
            base.OutAAddMath1(node);
        }
        public override void OutANextMath1(comp5210.node.ANextMath1 node)
        {
            base.OutANextMath1(node);
        }
        
        
        public override void OutADivideMath2(comp5210.node.ADivideMath2 node)
        {
            base.OutADivideMath2(node);
        }
        public override void OutAMultiplyMath2(comp5210.node.AMultiplyMath2 node)
        {
            base.OutAMultiplyMath2(node);
        }
        public override void OutANextMath2(comp5210.node.ANextMath2 node)
        {
            base.OutANextMath2(node);
        }


        public override void OutACallTopEndExp(comp5210.node.ACallTopEndExp node)
        {
            Definition exprdefn;
            nodehash.TryGetValue(node.GetExp(), out exprdefn);
            nodehash.Add(node, exprdefn);
        }
        public override void OutAEndEndExp(comp5210.node.AEndEndExp node)
        {
            Definition exprdefn;
            nodehash.TryGetValue(node.GetNumber(), out exprdefn);
            nodehash.Add(node, exprdefn);
         }



        public override void OutAIntNumber(comp5210.node.AIntNumber node)
        {
            //Console.WriteLine("hello int");
            BasicType inttype = new BasicType();
            inttype.name = "int";
            nodehash.Add(node, inttype);
        }
        public override void OutAFloatNumber(comp5210.node.AFloatNumber node)
        {
            //Console.WriteLine("hello float");
            BasicType flttype = new BasicType();
            flttype.name = "float";
            nodehash.Add(node, flttype);
            
                       
        }
        public override void OutAIdNumber(comp5210.node.AIdNumber node)
        {
            Definition iddefn;
            if (!stringhash.TryGetValue(node.GetId().Text, out iddefn))
            {
                Console.WriteLine("[" + node.GetId().Line + "]: " +
                    node.GetId().Text + " is not defined");
            }
            // you should really make sure that iddefn is a variable 
            // definition
            else
            {
                nodehash.Add(node, (iddefn as VariableDefinition).vartype);
            }
        }
        public override void OutAArrayNumber(comp5210.node.AArrayNumber node)
        {
            base.OutAArrayNumber(node);
        }
            
        }
       
        
     }

