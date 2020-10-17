//------------------------------------------------------------------------------
// <copyright file="QilFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <owner current="true" primary="true">Microsoft</owner>
//------------------------------------------------------------------------------

using System.Collections.Generic;

namespace System.Xml.Xsl.Qil {
    /// <summary>
    /// Factory methods for constructing QilExpression nodes.
    /// </summary>
    /// <remarks>
    /// See <see cref="http://dynamo/qil/qil.xml">the QIL functional specification</see> for documentation.
    /// </remarks>
    internal sealed class QilFactory {
        private QilTypeChecker typeCheck;

        public QilFactory() {
            this.typeCheck = new QilTypeChecker();
        }

        public QilTypeChecker TypeChecker {
            get { return this.typeCheck; }
        }

        
        //-----------------------------------------------
        // Convenience methods
        //-----------------------------------------------

        public QilExpression QilExpression(QilNode root, QilFactory factory) {
            QilExpression n = new QilExpression(QilNodeType.QilExpression, root, factory);
            n.XmlType = this.typeCheck.CheckQilExpression(n);
            TraceNode(n);
            return n;
        }

        public QilList FunctionList(IList<QilNode> values) {
            QilList seq = FunctionList();
            seq.Add(values);
            return seq;
        }

        public QilList GlobalVariableList(IList<QilNode> values) {
            QilList seq = GlobalVariableList();
            seq.Add(values);
            return seq;
        }

        public QilList GlobalParameterList(IList<QilNode> values) {
            QilList seq = GlobalParameterList();
            seq.Add(values);
            return seq;
        }

        public QilList ActualParameterList(IList<QilNode> values) {
            QilList seq = ActualParameterList();
            seq.Add(values);
            return seq;
        }

        public QilList FormalParameterList(IList<QilNode> values) {
            QilList seq = FormalParameterList();
            seq.Add(values);
            return seq;
        }

        public QilList SortKeyList(IList<QilNode> values) {
            QilList seq = SortKeyList();
            seq.Add(values);
            return seq;
        }

        public QilList BranchList(IList<QilNode> values) {
            QilList seq = BranchList();
            seq.Add(values);
            return seq;
        }

        public QilList Sequence(IList<QilNode> values) {
            QilList seq = Sequence();
            seq.Add(values);
            return seq;
        }

        public QilParameter Parameter(XmlQueryType xmlType) {
            return Parameter(null, null, xmlType);
        }

        public QilStrConcat StrConcat(QilNode values) {
            return StrConcat(LiteralString(""), values);
        }
        
        public QilName LiteralQName(string local) {
            return LiteralQName(local, string.Empty, string.Empty);
        }

        public QilTargetType TypeAssert(QilNode expr, XmlQueryType xmlType) {
            return TypeAssert(expr, (QilNode) LiteralType(xmlType));
        }

        public QilTargetType IsType(QilNode expr, XmlQueryType xmlType) {
            return IsType(expr, (QilNode) LiteralType(xmlType));
        }
        
        public QilTargetType XsltConvert(QilNode expr, XmlQueryType xmlType) {
            return XsltConvert(expr, (QilNode) LiteralType(xmlType));
        }

        public QilFunction Function(QilNode arguments, QilNode sideEffects, XmlQueryType xmlType) {
            return Function(arguments, Unknown(xmlType), sideEffects, xmlType);
        }


        #region AUTOGENERATED
        #region meta
        //-----------------------------------------------
        // meta
        //-----------------------------------------------
        public QilExpression QilExpression(QilNode root) {
            QilExpression n = new QilExpression(QilNodeType.QilExpression, root);
            n.XmlType = this.typeCheck.CheckQilExpression(n);
            TraceNode(n);
            return n;
        }
        
        public QilList FunctionList() {
            QilList n = new QilList(QilNodeType.FunctionList);
            n.XmlType = this.typeCheck.CheckFunctionList(n);
            TraceNode(n);
            return n;
        }
        
        public QilList GlobalVariableList() {
            QilList n = new QilList(QilNodeType.GlobalVariableList);
            n.XmlType = this.typeCheck.CheckGlobalVariableList(n);
            TraceNode(n);
            return n;
        }
        
        public QilList GlobalParameterList() {
            QilList n = new QilList(QilNodeType.GlobalParameterList);
            n.XmlType = this.typeCheck.CheckGlobalParameterList(n);
            TraceNode(n);
            return n;
        }
        
        public QilList ActualParameterList() {
            QilList n = new QilList(QilNodeType.ActualParameterList);
            n.XmlType = this.typeCheck.CheckActualParameterList(n);
            TraceNode(n);
            return n;
        }
        
        public QilList FormalParameterList() {
            QilList n = new QilList(QilNodeType.FormalParameterList);
            n.XmlType = this.typeCheck.CheckFormalParameterList(n);
            TraceNode(n);
            return n;
        }
        
        public QilList SortKeyList() {
            QilList n = new QilList(QilNodeType.SortKeyList);
            n.XmlType = this.typeCheck.CheckSortKeyList(n);
            TraceNode(n);
            return n;
        }
        
        public QilList BranchList() {
            QilList n = new QilList(QilNodeType.BranchList);
            n.XmlType = this.typeCheck.CheckBranchList(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary OptimizeBarrier(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.OptimizeBarrier, child);
            n.XmlType = this.typeCheck.CheckOptimizeBarrier(n);
            TraceNode(n);
            return n;
        }
        
        public QilNode Unknown(XmlQueryType xmlType) {
            QilNode n = new QilNode(QilNodeType.Unknown, xmlType);
            n.XmlType = this.typeCheck.CheckUnknown(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // meta
        
        #region specials
        //-----------------------------------------------
        // specials
        //-----------------------------------------------
        public QilDataSource DataSource(QilNode name, QilNode baseUri) {
            QilDataSource n = new QilDataSource(QilNodeType.DataSource, name, baseUri);
            n.XmlType = this.typeCheck.CheckDataSource(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Nop(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Nop, child);
            n.XmlType = this.typeCheck.CheckNop(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Error(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Error, child);
            n.XmlType = this.typeCheck.CheckError(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Warning(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Warning, child);
            n.XmlType = this.typeCheck.CheckWarning(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // specials
        
        #region variables
        //-----------------------------------------------
        // variables
        //-----------------------------------------------
        public QilIterator For(QilNode binding) {
            QilIterator n = new QilIterator(QilNodeType.For, binding);
            n.XmlType = this.typeCheck.CheckFor(n);
            TraceNode(n);
            return n;
        }
        
        public QilIterator Let(QilNode binding) {
            QilIterator n = new QilIterator(QilNodeType.Let, binding);
            n.XmlType = this.typeCheck.CheckLet(n);
            TraceNode(n);
            return n;
        }
        
        public QilParameter Parameter(QilNode defaultValue, QilNode name, XmlQueryType xmlType) {
            QilParameter n = new QilParameter(QilNodeType.Parameter, defaultValue, name, xmlType);
            n.XmlType = this.typeCheck.CheckParameter(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary PositionOf(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.PositionOf, child);
            n.XmlType = this.typeCheck.CheckPositionOf(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // variables
        
        #region literals
        //-----------------------------------------------
        // literals
        //-----------------------------------------------
        public QilNode True() {
            QilNode n = new QilNode(QilNodeType.True);
            n.XmlType = this.typeCheck.CheckTrue(n);
            TraceNode(n);
            return n;
        }
        
        public QilNode False() {
            QilNode n = new QilNode(QilNodeType.False);
            n.XmlType = this.typeCheck.CheckFalse(n);
            TraceNode(n);
            return n;
        }
        
        public QilLiteral LiteralString(string value) {
            QilLiteral n = new QilLiteral(QilNodeType.LiteralString, value);
            n.XmlType = this.typeCheck.CheckLiteralString(n);
            TraceNode(n);
            return n;
        }
        
        public QilLiteral LiteralInt32(int value) {
            QilLiteral n = new QilLiteral(QilNodeType.LiteralInt32, value);
            n.XmlType = this.typeCheck.CheckLiteralInt32(n);
            TraceNode(n);
            return n;
        }
        
        public QilLiteral LiteralInt64(long value) {
            QilLiteral n = new QilLiteral(QilNodeType.LiteralInt64, value);
            n.XmlType = this.typeCheck.CheckLiteralInt64(n);
            TraceNode(n);
            return n;
        }
        
        public QilLiteral LiteralDouble(double value) {
            QilLiteral n = new QilLiteral(QilNodeType.LiteralDouble, value);
            n.XmlType = this.typeCheck.CheckLiteralDouble(n);
            TraceNode(n);
            return n;
        }
        
        public QilLiteral LiteralDecimal(decimal value) {
            QilLiteral n = new QilLiteral(QilNodeType.LiteralDecimal, value);
            n.XmlType = this.typeCheck.CheckLiteralDecimal(n);
            TraceNode(n);
            return n;
        }
        
        public QilName LiteralQName(string localName, string namespaceUri, string prefix) {
            QilName n = new QilName(QilNodeType.LiteralQName, localName, namespaceUri, prefix);
            n.XmlType = this.typeCheck.CheckLiteralQName(n);
            TraceNode(n);
            return n;
        }
        
        public QilLiteral LiteralType(XmlQueryType value) {
            QilLiteral n = new QilLiteral(QilNodeType.LiteralType, value);
            n.XmlType = this.typeCheck.CheckLiteralType(n);
            TraceNode(n);
            return n;
        }
        
        public QilLiteral LiteralObject(object value) {
            QilLiteral n = new QilLiteral(QilNodeType.LiteralObject, value);
            n.XmlType = this.typeCheck.CheckLiteralObject(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // literals
        
        #region boolean operators
        //-----------------------------------------------
        // boolean operators
        //-----------------------------------------------
        public QilBinary And(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.And, left, right);
            n.XmlType = this.typeCheck.CheckAnd(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Or(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Or, left, right);
            n.XmlType = this.typeCheck.CheckOr(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Not(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Not, child);
            n.XmlType = this.typeCheck.CheckNot(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // boolean operators
        
        #region choice
        //-----------------------------------------------
        // choice
        //-----------------------------------------------
        public QilTernary Conditional(QilNode left, QilNode center, QilNode right) {
            QilTernary n = new QilTernary(QilNodeType.Conditional, left, center, right);
            n.XmlType = this.typeCheck.CheckConditional(n);
            TraceNode(n);
            return n;
        }
        
        public QilChoice Choice(QilNode expression, QilNode branches) {
            QilChoice n = new QilChoice(QilNodeType.Choice, expression, branches);
            n.XmlType = this.typeCheck.CheckChoice(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // choice
        
        #region collection operators
        //-----------------------------------------------
        // collection operators
        //-----------------------------------------------
        public QilUnary Length(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Length, child);
            n.XmlType = this.typeCheck.CheckLength(n);
            TraceNode(n);
            return n;
        }
        
        public QilList Sequence() {
            QilList n = new QilList(QilNodeType.Sequence);
            n.XmlType = this.typeCheck.CheckSequence(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Union(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Union, left, right);
            n.XmlType = this.typeCheck.CheckUnion(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Intersection(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Intersection, left, right);
            n.XmlType = this.typeCheck.CheckIntersection(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Difference(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Difference, left, right);
            n.XmlType = this.typeCheck.CheckDifference(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Average(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Average, child);
            n.XmlType = this.typeCheck.CheckAverage(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Sum(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Sum, child);
            n.XmlType = this.typeCheck.CheckSum(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Minimum(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Minimum, child);
            n.XmlType = this.typeCheck.CheckMinimum(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Maximum(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Maximum, child);
            n.XmlType = this.typeCheck.CheckMaximum(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // collection operators
        
        #region arithmetic operators
        //-----------------------------------------------
        // arithmetic operators
        //-----------------------------------------------
        public QilUnary Negate(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Negate, child);
            n.XmlType = this.typeCheck.CheckNegate(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Add(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Add, left, right);
            n.XmlType = this.typeCheck.CheckAdd(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Subtract(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Subtract, left, right);
            n.XmlType = this.typeCheck.CheckSubtract(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Multiply(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Multiply, left, right);
            n.XmlType = this.typeCheck.CheckMultiply(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Divide(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Divide, left, right);
            n.XmlType = this.typeCheck.CheckDivide(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Modulo(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Modulo, left, right);
            n.XmlType = this.typeCheck.CheckModulo(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // arithmetic operators
        
        #region string operators
        //-----------------------------------------------
        // string operators
        //-----------------------------------------------
        public QilUnary StrLength(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.StrLength, child);
            n.XmlType = this.typeCheck.CheckStrLength(n);
            TraceNode(n);
            return n;
        }
        
        public QilStrConcat StrConcat(QilNode delimiter, QilNode values) {
            QilStrConcat n = new QilStrConcat(QilNodeType.StrConcat, delimiter, values);
            n.XmlType = this.typeCheck.CheckStrConcat(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary StrParseQName(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.StrParseQName, left, right);
            n.XmlType = this.typeCheck.CheckStrParseQName(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // string operators
        
        #region value comparison operators
        //-----------------------------------------------
        // value comparison operators
        //-----------------------------------------------
        public QilBinary Ne(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Ne, left, right);
            n.XmlType = this.typeCheck.CheckNe(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Eq(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Eq, left, right);
            n.XmlType = this.typeCheck.CheckEq(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Gt(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Gt, left, right);
            n.XmlType = this.typeCheck.CheckGt(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Ge(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Ge, left, right);
            n.XmlType = this.typeCheck.CheckGe(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Lt(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Lt, left, right);
            n.XmlType = this.typeCheck.CheckLt(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Le(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Le, left, right);
            n.XmlType = this.typeCheck.CheckLe(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // value comparison operators
        
        #region node comparison operators
        //-----------------------------------------------
        // node comparison operators
        //-----------------------------------------------
        public QilBinary Is(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Is, left, right);
            n.XmlType = this.typeCheck.CheckIs(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary After(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.After, left, right);
            n.XmlType = this.typeCheck.CheckAfter(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Before(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Before, left, right);
            n.XmlType = this.typeCheck.CheckBefore(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // node comparison operators
        
        #region loops
        //-----------------------------------------------
        // loops
        //-----------------------------------------------
        public QilLoop Loop(QilNode variable, QilNode body) {
            QilLoop n = new QilLoop(QilNodeType.Loop, variable, body);
            n.XmlType = this.typeCheck.CheckLoop(n);
            TraceNode(n);
            return n;
        }
        
        public QilLoop Filter(QilNode variable, QilNode body) {
            QilLoop n = new QilLoop(QilNodeType.Filter, variable, body);
            n.XmlType = this.typeCheck.CheckFilter(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // loops
        
        #region sorting
        //-----------------------------------------------
        // sorting
        //-----------------------------------------------
        public QilLoop Sort(QilNode variable, QilNode body) {
            QilLoop n = new QilLoop(QilNodeType.Sort, variable, body);
            n.XmlType = this.typeCheck.CheckSort(n);
            TraceNode(n);
            return n;
        }
        
        public QilSortKey SortKey(QilNode key, QilNode collation) {
            QilSortKey n = new QilSortKey(QilNodeType.SortKey, key, collation);
            n.XmlType = this.typeCheck.CheckSortKey(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary DocOrderDistinct(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.DocOrderDistinct, child);
            n.XmlType = this.typeCheck.CheckDocOrderDistinct(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // sorting
        
        #region function definition and invocation
        //-----------------------------------------------
        // function definition and invocation
        //-----------------------------------------------
        public QilFunction Function(QilNode arguments, QilNode definition, QilNode sideEffects, XmlQueryType xmlType) {
            QilFunction n = new QilFunction(QilNodeType.Function, arguments, definition, sideEffects, xmlType);
            n.XmlType = this.typeCheck.CheckFunction(n);
            TraceNode(n);
            return n;
        }
        
        public QilInvoke Invoke(QilNode function, QilNode arguments) {
            QilInvoke n = new QilInvoke(QilNodeType.Invoke, function, arguments);
            n.XmlType = this.typeCheck.CheckInvoke(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // function definition and invocation
        
        #region XML navigation
        //-----------------------------------------------
        // XML navigation
        //-----------------------------------------------
        public QilUnary Content(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Content, child);
            n.XmlType = this.typeCheck.CheckContent(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Attribute(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Attribute, left, right);
            n.XmlType = this.typeCheck.CheckAttribute(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Parent(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Parent, child);
            n.XmlType = this.typeCheck.CheckParent(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Root(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Root, child);
            n.XmlType = this.typeCheck.CheckRoot(n);
            TraceNode(n);
            return n;
        }
        
        public QilNode XmlContext() {
            QilNode n = new QilNode(QilNodeType.XmlContext);
            n.XmlType = this.typeCheck.CheckXmlContext(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Descendant(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Descendant, child);
            n.XmlType = this.typeCheck.CheckDescendant(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary DescendantOrSelf(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.DescendantOrSelf, child);
            n.XmlType = this.typeCheck.CheckDescendantOrSelf(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Ancestor(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Ancestor, child);
            n.XmlType = this.typeCheck.CheckAncestor(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary AncestorOrSelf(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.AncestorOrSelf, child);
            n.XmlType = this.typeCheck.CheckAncestorOrSelf(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary Preceding(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.Preceding, child);
            n.XmlType = this.typeCheck.CheckPreceding(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary FollowingSibling(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.FollowingSibling, child);
            n.XmlType = this.typeCheck.CheckFollowingSibling(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary PrecedingSibling(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.PrecedingSibling, child);
            n.XmlType = this.typeCheck.CheckPrecedingSibling(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary NodeRange(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.NodeRange, left, right);
            n.XmlType = this.typeCheck.CheckNodeRange(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary Deref(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.Deref, left, right);
            n.XmlType = this.typeCheck.CheckDeref(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // XML navigation
        
        #region XML construction
        //-----------------------------------------------
        // XML construction
        //-----------------------------------------------
        public QilBinary ElementCtor(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.ElementCtor, left, right);
            n.XmlType = this.typeCheck.CheckElementCtor(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary AttributeCtor(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.AttributeCtor, left, right);
            n.XmlType = this.typeCheck.CheckAttributeCtor(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary CommentCtor(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.CommentCtor, child);
            n.XmlType = this.typeCheck.CheckCommentCtor(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary PICtor(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.PICtor, left, right);
            n.XmlType = this.typeCheck.CheckPICtor(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary TextCtor(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.TextCtor, child);
            n.XmlType = this.typeCheck.CheckTextCtor(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary RawTextCtor(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.RawTextCtor, child);
            n.XmlType = this.typeCheck.CheckRawTextCtor(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary DocumentCtor(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.DocumentCtor, child);
            n.XmlType = this.typeCheck.CheckDocumentCtor(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary NamespaceDecl(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.NamespaceDecl, left, right);
            n.XmlType = this.typeCheck.CheckNamespaceDecl(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary RtfCtor(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.RtfCtor, left, right);
            n.XmlType = this.typeCheck.CheckRtfCtor(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // XML construction
        
        #region Node properties
        //-----------------------------------------------
        // Node properties
        //-----------------------------------------------
        public QilUnary NameOf(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.NameOf, child);
            n.XmlType = this.typeCheck.CheckNameOf(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary LocalNameOf(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.LocalNameOf, child);
            n.XmlType = this.typeCheck.CheckLocalNameOf(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary NamespaceUriOf(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.NamespaceUriOf, child);
            n.XmlType = this.typeCheck.CheckNamespaceUriOf(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary PrefixOf(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.PrefixOf, child);
            n.XmlType = this.typeCheck.CheckPrefixOf(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // Node properties
        
        #region Type operators
        //-----------------------------------------------
        // Type operators
        //-----------------------------------------------
        public QilTargetType TypeAssert(QilNode source, QilNode targetType) {
            QilTargetType n = new QilTargetType(QilNodeType.TypeAssert, source, targetType);
            n.XmlType = this.typeCheck.CheckTypeAssert(n);
            TraceNode(n);
            return n;
        }
        
        public QilTargetType IsType(QilNode source, QilNode targetType) {
            QilTargetType n = new QilTargetType(QilNodeType.IsType, source, targetType);
            n.XmlType = this.typeCheck.CheckIsType(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary IsEmpty(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.IsEmpty, child);
            n.XmlType = this.typeCheck.CheckIsEmpty(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // Type operators
        
        #region XPath operators
        //-----------------------------------------------
        // XPath operators
        //-----------------------------------------------
        public QilUnary XPathNodeValue(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.XPathNodeValue, child);
            n.XmlType = this.typeCheck.CheckXPathNodeValue(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary XPathFollowing(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.XPathFollowing, child);
            n.XmlType = this.typeCheck.CheckXPathFollowing(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary XPathPreceding(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.XPathPreceding, child);
            n.XmlType = this.typeCheck.CheckXPathPreceding(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary XPathNamespace(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.XPathNamespace, child);
            n.XmlType = this.typeCheck.CheckXPathNamespace(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // XPath operators
        
        #region XSLT
        //-----------------------------------------------
        // XSLT
        //-----------------------------------------------
        public QilUnary XsltGenerateId(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.XsltGenerateId, child);
            n.XmlType = this.typeCheck.CheckXsltGenerateId(n);
            TraceNode(n);
            return n;
        }
        
        public QilInvokeLateBound XsltInvokeLateBound(QilNode name, QilNode arguments) {
            QilInvokeLateBound n = new QilInvokeLateBound(QilNodeType.XsltInvokeLateBound, name, arguments);
            n.XmlType = this.typeCheck.CheckXsltInvokeLateBound(n);
            TraceNode(n);
            return n;
        }
        
        public QilInvokeEarlyBound XsltInvokeEarlyBound(QilNode name, QilNode clrMethod, QilNode arguments, XmlQueryType xmlType) {
            QilInvokeEarlyBound n = new QilInvokeEarlyBound(QilNodeType.XsltInvokeEarlyBound, name, clrMethod, arguments, xmlType);
            n.XmlType = this.typeCheck.CheckXsltInvokeEarlyBound(n);
            TraceNode(n);
            return n;
        }
        
        public QilBinary XsltCopy(QilNode left, QilNode right) {
            QilBinary n = new QilBinary(QilNodeType.XsltCopy, left, right);
            n.XmlType = this.typeCheck.CheckXsltCopy(n);
            TraceNode(n);
            return n;
        }
        
        public QilUnary XsltCopyOf(QilNode child) {
            QilUnary n = new QilUnary(QilNodeType.XsltCopyOf, child);
            n.XmlType = this.typeCheck.CheckXsltCopyOf(n);
            TraceNode(n);
            return n;
        }
        
        public QilTargetType XsltConvert(QilNode source, QilNode targetType) {
            QilTargetType n = new QilTargetType(QilNodeType.XsltConvert, source, targetType);
            n.XmlType = this.typeCheck.CheckXsltConvert(n);
            TraceNode(n);
            return n;
        }
        
        #endregion // XSLT
        
        #endregion

        #region Diagnostic Support
    #if QIL_TRACE_NODE_CREATION
        internal sealed class Diagnostics {
            private int nodecnt = 0;
            private ArrayList nodelist = new ArrayList();

            public ArrayList NodeTable { get { return nodelist; } }

            public void AddNode(QilNode n) {
                nodelist.Add(n);
                n.NodeId = nodecnt++;
                StackTrace st = new StackTrace(true);
                for (int i = 1; i < st.FrameCount; i++) {
                    StackFrame sf = st.GetFrame(i);
                    Type mt = sf.GetMethod().DeclaringType;
                    if (mt != typeof(QilFactory) && mt != typeof(QilPatternFactory))
                    {
                        n.NodeLocation = mt.FullName + "." + sf.GetMethod().Name + " (" + sf.GetFileName() +
                                         ": " + sf.GetFileLineNumber() + "," + sf.GetFileColumnNumber() + ")";
                        break;
                    }
                }
            }
        }

        private Diagnostics diag = new Diagnostics();

        public Diagnostics DebugInfo {
            get { return diag; }
            set { diag = value; }
        }
    #endif

        [System.Diagnostics.Conditional("QIL_TRACE_NODE_CREATION")]
        public void TraceNode(QilNode n) {
    #if QIL_TRACE_NODE_CREATION
            this.diag.AddNode(n);
    #endif
        }
        #endregion
    }
}
