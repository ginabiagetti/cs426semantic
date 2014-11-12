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
            BasicType booltype = new BasicType();
            booltype.name = "boolean";
            BasicType intarraytype = new BasicType();
            intarraytype.name = "intarray";
            BasicType fltarraytype = new BasicType();
            fltarraytype.name = "floatarray";
            BasicType methodtype = new BasicType();
            methodtype.name = "method";

            stringhash.Add(inttype.name, inttype);
            stringhash.Add(flttype.name, flttype);
            stringhash.Add(booltype.name, booltype);
            stringhash.Add(intarraytype.name, intarraytype);
            stringhash.Add(fltarraytype.name, fltarraytype);
            stringhash.Add(methodtype.name, methodtype);
            
        }
        public override void OutAFullMethodHeader(comp5210.node.AFullMethodHeader node)
        {
            Definition typedefn;
            stringhash.TryGetValue("method", out typedefn);
            string name = node.GetName().Text;
            stringhash.Add(name, typedefn);

        }
        public override void OutAEmptyMethodHeader(comp5210.node.AEmptyMethodHeader node)
        {
            Definition typedefn;
            stringhash.TryGetValue("method", out typedefn);
            string name = node.GetName().Text;
            stringhash.Add(name, typedefn);
        }
        public override void OutACallProcedureCall(comp5210.node.ACallProcedureCall node)
        {
            Definition typedefn, methodtype;
            stringhash.TryGetValue("method", out methodtype);
            // check method variable has been declared
            if (!stringhash.TryGetValue(node.GetId().Text, out typedefn))
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    node.GetId().Text + " hasn't been declared");

            //check if it was declared as a method
            }else if (typedefn != methodtype)
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    node.GetId().Text + " hasn't been declared as a method");
            }
        }
        public override void OutANothingProcedureCall(comp5210.node.ANothingProcedureCall node)
        {
            Definition typedefn, methodtype;
            stringhash.TryGetValue("method", out methodtype);
            // check method variable has been declared
            if (!stringhash.TryGetValue(node.GetId().Text, out typedefn))
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    node.GetId().Text + " hasn't been declared");

                //check if it was declared as a method
            }
            else if (typedefn != methodtype)
            {
                Console.WriteLine("[" + node.GetSemicolon().Line + "]: " +
                    node.GetId().Text + " hasn't been declared as a method");
            }
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
                    Console.WriteLine("added " + vardefn.name + " of type " + vardefn.vartype.name+ " to the stringhash");
                }
                
            }
       }
        public override void OutAArrayDeclare(comp5210.node.AArrayDeclare node)
        {
            string type = node.GetType().Text;
            string name = node.GetName().Text;
            Definition typedefn;
            // lookup the type
            if (type == "int")
            {
                stringhash.TryGetValue("intarray", out typedefn);

                // check to make sure what we got back is a type
                if (!(typedefn is TypeDefinition))
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
                        Console.WriteLine("added " + name + " of type " + vardefn.vartype.name + " to the stringhash");
                    }

                }
            }
            else if (type == "float")
            {
                stringhash.TryGetValue("floatarray", out typedefn);

                // check to make sure what we got back is a type
                if (!(typedefn is TypeDefinition))
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
                        Console.WriteLine("added " + name + " of type " + vardefn.vartype.name + " to the stringhash");
                    }

                }
            }
            else
            {
                Console.WriteLine(type + " is not a type");
            }
        }

        public override void OutAIfStatement(comp5210.node.AIfStatement node)
        {
            Definition typedefn, booltype;
            nodehash.TryGetValue(node.GetExp(), out typedefn);
            stringhash.TryGetValue("boolean", out booltype);

            // checks if the statement inside the paranthesis is boolean
            if (typedefn != booltype)
            {
                Console.WriteLine("[" + node.GetIf().Line +
                    "]: If statements must have a boolean expression");
            }
        }
        public override void OutAWhileLoop(comp5210.node.AWhileLoop node)
        {
            Definition typedefn, booltype;
            nodehash.TryGetValue(node.GetExp(), out typedefn);
            stringhash.TryGetValue("boolean", out booltype);
            
            // checks if the statement inside the paranthesis is boolean
            if (typedefn != booltype)
            {
                Console.WriteLine("[" + node.GetWhile().Line +
                    "]: While statements must have a boolean expression");
            }
        }


        public override void OutAExpressionAssignStatement(comp5210.node.AExpressionAssignStatement node)
        {
            Definition rhs, lhs; 
            Definition booltype;
            stringhash.TryGetValue("boolean", out booltype);
           
            // check if variable has been declared
            if (!stringhash.TryGetValue(node.GetId().Text, out lhs))
            {
                Console.WriteLine("[" + node.GetEquals().Line + "]: " +
                    node.GetId().Text + " hasn't been declared");
            }
            // checking type of the expression
            else if (!nodehash.TryGetValue(node.GetExp(), out rhs))
            {
                Console.WriteLine("[" + node.GetExp() + "]: " +
                   "can't be found");
            }
            // check if set equal to boolean
            else if(rhs == booltype)
            {
               Console.WriteLine("[" + node.GetEquals().Line + "]: " +
                    "can't assign a number as a boolean");
            }
            // check if both side are the same type
            else if ((lhs as VariableDefinition).vartype != rhs)
            {
                Console.WriteLine("[" + node.GetEquals().Line + "]: " +
                    "types don't match");
            }

 
 
        }
        public override void OutAArrayAssignStatement(comp5210.node.AArrayAssignStatement node)
        {
            Definition rhs, lhs, bracket;
            Definition booltype, intarraytype, fltarraytype, inttype, flttype;
            // get boolean type
            stringhash.TryGetValue("boolean", out booltype);
            stringhash.TryGetValue("intarray", out intarraytype);
            stringhash.TryGetValue("floatarray", out fltarraytype);
            stringhash.TryGetValue("int", out inttype);
            stringhash.TryGetValue("float", out flttype);

            // check if variable has been declared
            if (!stringhash.TryGetValue(node.GetId().Text, out lhs))
            {
                Console.WriteLine("[" + node.GetEquals().Line + "]: " +
                    node.GetId().Text + " hasn't been declared");
                
            }
            // check if it is declared as an array
            else if (!((lhs == intarraytype) || (lhs == fltarraytype)))
            {
                Console.WriteLine("[" + node.GetEquals().Line + "]: " +
                    node.GetId().Text + " hasn't been declared as an array");
            }            
            // check type of the expression within brackets
            else if (!nodehash.TryGetValue(node.GetInBracket(), out bracket))
            {
                Console.WriteLine("[" + node.GetInBracket() + "]: " +
                   "can't be found");
            }
            // check if set equal to boolean
            else if (bracket == booltype)
            {
                Console.WriteLine("[" + node.GetEquals().Line + "]: " +
                     "can't assign a number as a boolean");
            }
            // checking type of the expression
            else if (!nodehash.TryGetValue(node.GetEqualto(), out rhs))
            {
                Console.WriteLine("[" + node.GetEqualto() + "]: " +
                   "can't be found");
            }
            // check if set equal to boolean
            else if (rhs == booltype)
            {
                Console.WriteLine("[" + node.GetEquals().Line + "]: " +
                     "can't assign a number as a boolean");
            }
            // check if both side are the same type
            else if (!(((lhs == intarraytype) && (rhs == inttype)) || ((lhs == fltarraytype) && (rhs == flttype))))
            {
                Console.WriteLine("[" + node.GetEquals().Line + "]: " +
                    "types don't match");
            }
            
        }
      

        public override void OutAMoreFormalParameters(comp5210.node.AMoreFormalParameters node)
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
                Console.WriteLine("[" + node.GetComma().Line + "]: " +
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
                    Console.WriteLine("[" + node.GetComma().Line + "]: " +
                    name + " has already been declared.");
                }
                else
                {//if not, then add it to the hash!
                    stringhash.Add(vardefn.name, vardefn);
                    Console.WriteLine("added " + vardefn.name + " of type " + vardefn.vartype.name + " to the stringhash");
                }

            }
        }
        public override void OutALastFormalParameters(comp5210.node.ALastFormalParameters node)
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
                Console.WriteLine("[" + node.GetType().Line + "]: " +
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
                    Console.WriteLine("[" + node.GetType().Line + "]: " +
                    name + " has already been declared.");
                }
                else
                {//if not, then add it to the hash!
                    stringhash.Add(vardefn.name, vardefn);
                    Console.WriteLine("added " + vardefn.name + " of type " + vardefn.vartype.name + " to the stringhash");
                }

            }
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
            Definition prevdefn;
            Definition nextdefn;
            nodehash.TryGetValue(node.GetExp(), out prevdefn);
            nodehash.TryGetValue(node.GetComparators(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                Definition typedefn;
                stringhash.TryGetValue("boolean", out typedefn);
                // set this node type to boolean
                nodehash.Add(node, typedefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetOr().Line + "]: Mismatched variable types");
            }
        }
        public override void OutAAndExp(comp5210.node.AAndExp node)
        {
            Definition prevdefn;
            Definition nextdefn;
            nodehash.TryGetValue(node.GetExp(), out prevdefn);
            nodehash.TryGetValue(node.GetComparators(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                Definition typedefn;
                stringhash.TryGetValue("boolean", out typedefn);
                // set this node type to boolean
                nodehash.Add(node, typedefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetAnd().Line + "]: Mismatched variable types");
            }
        }
        public override void OutANotEqualExp(comp5210.node.ANotEqualExp node)
        {
            Definition prevdefn;
            Definition nextdefn;
            nodehash.TryGetValue(node.GetExp(), out prevdefn);
            nodehash.TryGetValue(node.GetComparators(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                Definition typedefn;
                stringhash.TryGetValue("boolean", out typedefn);
                // set this node type to boolean
                nodehash.Add(node, typedefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetNotEqual().Line + "]: Mismatched variable types");
            }
        }
        public override void OutAEqualToExp(comp5210.node.AEqualToExp node)
        {
            Definition prevdefn;
            Definition nextdefn;
            nodehash.TryGetValue(node.GetExp(), out prevdefn);
            nodehash.TryGetValue(node.GetComparators(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                Definition typedefn;
                stringhash.TryGetValue("boolean", out typedefn);
                // set this node type to boolean
                nodehash.Add(node, typedefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetEqualTo().Line + "]: Mismatched variable types");
            }
        }
        public override void OutANextExp(comp5210.node.ANextExp node)
        {
            Definition exprdefn;
            nodehash.TryGetValue(node.GetComparators(), out exprdefn);
            // set the type of this node as its child's node
            nodehash.Add(node, exprdefn);
        }
        
        
        public override void OutAGreaterThanComparators(comp5210.node.AGreaterThanComparators node)
        {
            Definition prevdefn;
            Definition nextdefn;

            nodehash.TryGetValue(node.GetOne(), out prevdefn);
            nodehash.TryGetValue(node.GetTwo(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                Definition typedefn;
                stringhash.TryGetValue("boolean", out typedefn);
                // set this node type to boolean
                nodehash.Add(node, typedefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetGreaterThan().Line + "]: Mismatched variable types");
            }
        }
        public override void OutALessThanComparators(comp5210.node.ALessThanComparators node)
        {
            Definition prevdefn;
            Definition nextdefn;
            nodehash.TryGetValue(node.GetOne(), out prevdefn);
            nodehash.TryGetValue(node.GetTwo(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                Definition typedefn;
                stringhash.TryGetValue("boolean", out typedefn);
                // set this node type to boolean
                nodehash.Add(node, typedefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetLessThan().Line + "]: Mismatched variable types");
            }
        }
        public override void OutAGreaterEqualComparators(comp5210.node.AGreaterEqualComparators node)
        {
            Definition prevdefn;
            Definition nextdefn;
            nodehash.TryGetValue(node.GetOne(), out prevdefn);
            nodehash.TryGetValue(node.GetTwo(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                Definition typedefn;
                stringhash.TryGetValue("boolean", out typedefn);
                // set this node type to boolean
                nodehash.Add(node, typedefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetGreaterEqual().Line + "]: Mismatched variable types");
            }
        }
        public override void OutALessEqualComparators(comp5210.node.ALessEqualComparators node)
        {
            Definition prevdefn;
            Definition nextdefn;
            nodehash.TryGetValue(node.GetOne(), out prevdefn);
            nodehash.TryGetValue(node.GetTwo(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                Definition typedefn;
                stringhash.TryGetValue("boolean", out typedefn);
                // set this node type to boolean
                nodehash.Add(node, typedefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetLessEqual().Line + "]: Mismatched variable types");
            }
        }
        public override void OutANextComparators(comp5210.node.ANextComparators node)
        {
            Definition exprdefn;
            nodehash.TryGetValue(node.GetMath1(), out exprdefn);
            // set the type of this node as its child's node
            nodehash.Add(node, exprdefn);
        }
        
        
        public override void OutASubtractMath1(comp5210.node.ASubtractMath1 node)
        {
            Definition prevdefn;
            Definition nextdefn;
            nodehash.TryGetValue(node.GetMath1(), out prevdefn);
            nodehash.TryGetValue(node.GetMath2(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                // set this node type to the type of its children
                nodehash.Add(node, prevdefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetMinus().Line + "]: Mismatched variable types");
            }
        }
        public override void OutAAddMath1(comp5210.node.AAddMath1 node)
        {
            Definition prevdefn;
            Definition nextdefn;
            nodehash.TryGetValue(node.GetMath1(), out prevdefn);
            nodehash.TryGetValue(node.GetMath2(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                // set this node type to the type of its children
                nodehash.Add(node, prevdefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetPlus().Line + "]: Mismatched variable types");
            }
        }
        public override void OutANextMath1(comp5210.node.ANextMath1 node)
        {
            Definition exprdefn;
            nodehash.TryGetValue(node.GetMath2(), out exprdefn);
            // set the type of this node as its child's node
            nodehash.Add(node, exprdefn);
        }
        
        
        public override void OutADivideMath2(comp5210.node.ADivideMath2 node)
        {
            Definition prevdefn;
            Definition nextdefn;
            nodehash.TryGetValue(node.GetMath2(), out prevdefn);
            nodehash.TryGetValue(node.GetEndExp(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                // set this node type to the type of its children
                nodehash.Add(node, prevdefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetDivide().Line + "]: Mismatched variable types");
            }
        }
        public override void OutAMultiplyMath2(comp5210.node.AMultiplyMath2 node)
        {            
            Definition prevdefn;
            Definition nextdefn;
            nodehash.TryGetValue(node.GetMath2(), out prevdefn);
            nodehash.TryGetValue(node.GetEndExp(), out nextdefn);

            // if the types of each side match up
            if (prevdefn == nextdefn)
            {
                // set this node type to the type of its children
                nodehash.Add(node, prevdefn);
            }
            else
            {
                Console.WriteLine("[" + node.GetMultiply().Line + "]: Mismatched variable types");
            }
        }
        public override void OutANextMath2(comp5210.node.ANextMath2 node)
        {
            Definition exprdefn;
            nodehash.TryGetValue(node.GetEndExp(), out exprdefn);
            nodehash.Add(node, exprdefn);
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
            Definition typedefn;
            stringhash.TryGetValue("int", out typedefn);
            nodehash.Add(node, typedefn);
        }
        public override void OutAFloatNumber(comp5210.node.AFloatNumber node)
        {
            
            Definition typedefn;
            stringhash.TryGetValue("float", out typedefn);
            nodehash.Add(node, typedefn);
            
                       
        }
        public override void OutAIdNumber(comp5210.node.AIdNumber node)
        {
            Definition iddefn;
            if (!stringhash.TryGetValue(node.GetId().Text, out iddefn))
            {
                Console.WriteLine("[" + node.GetId().Line + "]: " +
                    node.GetId().Text + " is not defined");
            }
            // make sure that iddefn is a variable definition
            else
            {
                nodehash.Add(node, iddefn);
            }
        }
        public override void OutAArrayNumber(comp5210.node.AArrayNumber node)
        {
            Definition intarraytype, fltarraytype, inttype, flttype;
            // get boolean type
            stringhash.TryGetValue("intarray", out intarraytype);
            stringhash.TryGetValue("floatarray", out fltarraytype);
            stringhash.TryGetValue("int", out inttype);
            stringhash.TryGetValue("float", out flttype);
            Definition iddefn;
            if (!stringhash.TryGetValue(node.GetId().Text, out iddefn))
            {
                Console.WriteLine("[" + node.GetId().Line + "]: " +
                    node.GetId().Text + " is not defined");
            }
            // make sure that iddefn is a variable definition
            else if(iddefn == intarraytype)
            {
                nodehash.Add(node, (inttype as VariableDefinition).vartype);
            }
            else if (iddefn == fltarraytype)
            {
                nodehash.Add(node, (flttype as VariableDefinition).vartype);
            }
        }
            
    }
       
        
}

