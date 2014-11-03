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

        public override void OutAIntDeclareConstantDeclare(comp5210.node.AIntDeclareConstantDeclare node)
        {
            base.OutAIntDeclareConstantDeclare(node);
        }
      
        public override void OutAFloatDelcareConstantDeclare(comp5210.node.AFloatDelcareConstantDeclare node)
        {
            base.OutAFloatDelcareConstantDeclare(node);
        }
        public override void OutAVarDeclare(comp5210.node.AVarDeclare node)
        {
            base.OutAVarDeclare(node);
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
            base.OutAExpressionAssignStatement(node);
        }
        public override void OutAArrayAssignStatement(comp5210.node.AArrayAssignStatement node)
        {
            base.OutAArrayAssignStatement(node);
        }
        public override void OutAArrayDeclare(comp5210.node.AArrayDeclare node)
        {
            base.OutAArrayDeclare(node);
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
            base.OutACallTopEndExp(node);
        }
        public override void OutAEndEndExp(comp5210.node.AEndEndExp node)
        {
            base.OutAEndEndExp(node);
        }

        public override void OutAIntNumber(comp5210.node.AIntNumber node)
        {
            base.OutAIntNumber(node);
        }
        public override void OutAFloatNumber(comp5210.node.AFloatNumber node)
        {
            base.OutAFloatNumber(node);
        }
        public override void OutAIdNumber(comp5210.node.AIdNumber node)
        {
            base.OutAIdNumber(node);
        }
        public override void OutAArrayNumber(comp5210.node.AArrayNumber node)
        {
            base.OutAArrayNumber(node);
        }
    }
}
