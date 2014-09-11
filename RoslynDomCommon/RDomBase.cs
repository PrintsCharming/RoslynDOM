﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using RoslynDom.Common;

namespace RoslynDom
{

    /// <summary>
    /// Base class for Roslyn Dom navigation tree
    /// </summary>
    /// <remarks>
    /// Initialize must be called near end of the constructor. Existing RDom impelementations all do this.
    /// </remarks>
    public abstract class RDomBase : IDom
    {
 
        private PublicAnnotationList _publicAnnotations = new PublicAnnotationList();

        protected RDomBase()
        { Whitespace2Set = new Whitespace2Collection(); }

        protected RDomBase(IDom oldIDom) : this()
        {
            if (oldIDom == null) throw new NotImplementedException();
            var oldRDom = (RDomBase)oldIDom;
            Whitespace2Set = oldIDom.Whitespace2Set.Copy();
            var oldAsHasName = oldIDom as IHasName;
            var thisAsHasName = this as IHasName;
            if (oldAsHasName != null && thisAsHasName != null)
            { thisAsHasName.Name = oldAsHasName.Name; }

            var newPublicAnnotations = oldRDom._publicAnnotations.Copy();
            _publicAnnotations.Add(newPublicAnnotations);

            var thisAsHasStructuredDocs = this as IHasStructuredDocumentation;
            if (thisAsHasStructuredDocs != null)
            {
                var otherAsHasStructuredDocs = (IHasStructuredDocumentation)oldIDom;
                thisAsHasStructuredDocs.StructuredDocumentation = otherAsHasStructuredDocs.StructuredDocumentation;
                thisAsHasStructuredDocs.Description = otherAsHasStructuredDocs.Description;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Return type is object, not SyntaxNode to match interface
        /// </remarks>
        public abstract object RawItem { get; }

        public abstract object OriginalRawItem { get; }

        // TODO: Return the parent set to hidden
        public IDom Parent { get; set; }

        public override string ToString()
        {
            var ret = base.ToString() + " : ";
            var thisHasNamespace = this as IHasNamespace;
            if (thisHasNamespace != null) return ret + thisHasNamespace.QualifiedName;
            var thisHasName = this as IHasName;
            if (thisHasName != null) return ret + thisHasName.Name;
            if (this is IStatement) return ret;
            if (this is IExpression) return ret + this.RawItem.ToString();

            return ret;
        }

        public virtual string ReportHierarchy()
        {
            return ReportHierarchy(false);
        }

        public virtual string ReportHierarchy(bool includeWhitespace)
        {
            var sb = new StringBuilder();
            var spaces = 2;
            var indentToAdd = new string(' ', spaces);
            var indent = "";
            var reversedAncestors = this.Ancestors.Reverse();
            foreach (var ancestor in reversedAncestors)
            {
                sb.AppendLine(indent + ancestor.ToString());
                indent += indentToAdd;
            }
            sb.AppendLine(indent + this.ToString());
            AppendChildHierarchy(this, sb, indent + indentToAdd, indentToAdd);
            return sb.ToString();
        }

        private static void AppendChildHierarchy(IDom item, StringBuilder sb, string indent, string indentToAdd)
        {
            foreach (var child in item.Children)
            {
                sb.AppendLine(indent + child.ToString());
                AppendChildHierarchy(child, sb, indent + indentToAdd, indentToAdd);
            }
        }

        public abstract object RequestValue(string propertyName);

        public virtual bool Matches(IDom other)
        {
            var thisAsHasName = this as IHasName;
            var otherAsHasName = other as IHasName;
            if (thisAsHasName != null && otherAsHasName != null)
            { return thisAsHasName.Name == otherAsHasName.Name; }
            return false; // we can't test here
        }

        public bool SameIntent<TLocal>(TLocal other)
               where TLocal : class
        {
            return SameIntent(other, false);
        }

        public bool SameIntent<TLocal>(TLocal other, bool skipPublicAnnotations)
         where TLocal : class
        {
            return SameIntentInternal(other, skipPublicAnnotations);
        }

        protected abstract bool SameIntentInternal<TLocal>(TLocal other, bool skipPublicAnnotations)
                         where TLocal : class;


        public PublicAnnotationList PublicAnnotations
        { get { return _publicAnnotations; } }

        public virtual IEnumerable<IDom> Descendants
        { get { return new List<IDom>(); } }

        public IEnumerable<IDom> DescendantsAndSelf
        {
            get
            {
                var list = Descendants.ToList();
                list.Insert(0, this);
                return list;
            }
        }

        public virtual IEnumerable<IDom> Children
        { get { return new List<IDom>(); } }

        public virtual IEnumerable<IDom> Ancestors
        {
            get
            {
                if (Parent == null) { return new List<IDom>(); } // top/end of recursion
                return Parent.AncestorsAndSelf;
            }
        }

        public IEnumerable<IDom> AncestorsAndSelf
        {
            get
            {
                var list = Ancestors.ToList();
                list.Insert(0, this);
                return list;
            }
        }

        public Whitespace2Collection Whitespace2Set { get; private set; }

    }
}