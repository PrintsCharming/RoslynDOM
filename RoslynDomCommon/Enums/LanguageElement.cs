﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynDom.Common
{
    public enum LanguageElement
    {
        Comment,
        DocumentationComment,
        EndOfLine,

        AttributeSurroundStart,
        AttributeSurroundEnd,
        AttributeParameterStart,
        AttributeParameterEnd,
        AttributeValueFirstToken,
        AttributeValueName,
        AttributeValueEqualsOrColon,
        AttributeValueLastToken,

        TypeParameterStartDelimiter,
        TypeParameterEndDelimiter,
        TypeParameterSeparator,

        ParameterStartDelimiter,
        ParameterEndDelimiter,
        ParameterSeparator,
        ParameterDefaultAssignOperator,
        ParameterFirstToken,
        ParameterLastToken,

        CodeBlockStart,
        CodeBlockEnd,

        ConditionStart,
        ConditionEnd,

        UsingKeyword,
        
        NamespaceKeyword,
        NamespaceStartDelimiter,
        NamespaceEndDelimiter,

        ClassKeyword,
        ClassStartDelimiter,
        ClassEndDelimiter,

        StructureKeyword,
        StructureStartDelimiter,
        StructureEndDelimiter,

        EnumKeyword,
        EnumValuesStartDelimiter,
        EnumValuesEndDelimiter,
        EnumValueAssignOperator,
        EnumValueSeparator,
        EnumValueFirstToken,
        EnumValueLastToken,

        InterfaceKeyword,
        InterfaceStartDelimiter,
        InterfaceEndDelimiter,

        MethodSubKeyword,      // not used in C#
        MethodFunctionKeyword, // not used in C#

        StatementBlockStartDelimiter,
        StatementBlockEndDelimiter,
 
        AccessorGetKeyword,
        AccessorSetKeyword,
        AccessorAddEventKeyword,
        AccessorRemoveEventKeyword,
        AccessorStartDelimiter,
        AccessorEndDelimiter,
        AccessorGroupStartDelimiter,
        AccessorGroupEndDelimiter,
        AccessorShortFormIndicator,

        NotApplicable,
        Private,
        ProtectedAndInternal,
        ProtectedAndFriend = ProtectedAndInternal,
        Protected,
        Internal,
        Friend = Internal,
        ProtectedOrInternal,
        ProtectedOrFriend = ProtectedOrInternal,
        Public,

        Identifier,
        Type,

        Abstract,
        Override,
        Sealed,
        Virtual,

        Static,
        ReturnKeyword,
        Expression,
        LeftExpression,

        AssignmentOperator,
        EqualsAssignmentOperator,
        AddAssignmentOperator,
        SubtractAssignmentOperator,
        MultiplyAssignmentOperator,
        DivideAssignmentOperator,
        ModuloAssignmentOperator,
        AndAssignmentOperator,
        ExclusiveOrAssignmentOperator,
        OrAssignmentOperator,
        LeftShiftAssignmentOperator,
        RightShiftAssignmentOperator,

        IfKeyword,
        ElseKeyword,
        DoKeyword,
        ForKeyword,
        ForEachKeyword,
        InKeyword,
        WhileKeyword,
        ConditionalStartDelimiter,
        ConditionalEndDelimiter,
        TryKeyword,
        CatchKeyword,
        FinallyKeyword,
        NewSlot,
        Locked,
        Checked,
        Unchecked,
        Throw,
        Using,
        Constant,
        Readonly,
        VariableStartDelimiter,
        VariableEndDelimiter,
        Separator,
        Current,
        BaseListPrefix,
        ThisForExtension,
        Volatile,
        TypeParameterStart,
        TypeParameterEnd,
        ConstraintKeyword,
        ConstraintColon,
        ConstraintSeparator,
        ClassConstraint,
        ValueConstraint,
        ConstructorConstraint,
        ConstructorInitializerPrefix,
        ConstructorBaseInitializer,
        ConstructorThisInitializer,
    }
}