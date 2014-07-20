﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RoslynDom.Common;

namespace RoslynDom.CSharp
{
    public class RDomRootFactory
          : RDomRootContainerFactory<RDomRoot, CompilationUnitSyntax>
    {
        public override IEnumerable<IRoot> CreateFrom(SyntaxNode syntaxNode, IDom parent,SemanticModel model)
        {
            var syntax = syntaxNode as CompilationUnitSyntax;
            var newItem = new RDomRoot(syntaxNode, parent,model);

            newItem.Name = "Root";
            var members = ListUtilities.MakeList(syntax, x => x.Members, x => RDomFactoryHelper.GetHelper<IStemMember >().MakeItem(x,newItem,  model));
            var usings = ListUtilities.MakeList(syntax, x => x.Usings, x => RDomFactoryHelper.GetHelper<IStemMember>().MakeItem(x, newItem, model));
            foreach (var member in members)
            { newItem.AddOrMoveStemMember(member); }
            foreach (var member in usings)
            { newItem.AddOrMoveStemMember(member); }

            return new IRoot[] { newItem };
        }

        public override IEnumerable<SyntaxNode> BuildSyntax(IRoot item)
        {
            var node = SyntaxFactory.CompilationUnit();
            var usingsSyntax = item.Usings
                        .SelectMany(x => RDomCSharpFactory.Factory.BuildSyntaxGroup(x))
                        .ToList();
            var membersSyntax = item.StemMembers
                        .Where(x=>!(x is IUsing))
                        .SelectMany(x => RDomCSharpFactory.Factory.BuildSyntaxGroup(x))
                        .ToList();
            node = node.WithUsings(SyntaxFactory.List(usingsSyntax));
            node = node.WithMembers(SyntaxFactory.List(membersSyntax));
            return new SyntaxNode[] { RoslynUtilities.Format(node) };
        }
    }


}