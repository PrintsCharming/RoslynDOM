﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoslynDom;
using RoslynDom.CSharp;

namespace RoslynDomTests
{
   [TestClass]
   public class DiagnosticsTests
   {
      private const string DiagnosticsTestsCategory = "DiagnosticsTests";

      [TestMethod, TestCategory(DiagnosticsTestsCategory)]
      public void No_diagnostics_for_correct_happy_case()
      {
         var csharpCode = @"
            //[[root:kad_Test1()]]
            public class MyClass
            {
                public string Foo{get; set;} 
            }
            ";
         var root = RDom.CSharp.Load(csharpCode);
         Assert.IsFalse(root.HasSyntaxErrors);

      }

      [TestMethod, TestCategory(DiagnosticsTestsCategory)]
      public void Find_diagnostics_issue_for_unhappy_case()
      {
         Assert.Inconclusive("Add IncompleteMemberSynta support");
         var csharpCode = @"
            //[[root:kad_Test1()]]
            public class MyClass
            {
                public string Foo(getx; set;} 
            }
            ";
         var root = RDom.CSharp.Load(csharpCode);
         Assert.IsTrue(root.HasSyntaxErrors);

      }
   }
}
