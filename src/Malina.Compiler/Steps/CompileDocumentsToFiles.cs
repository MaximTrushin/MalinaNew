﻿using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Malina.DOM;
using Malina.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malina.Compiler.Steps
{
    class CompileDocumentsToFiles : ICompilerStep
    {
        CompilerContext _context;
        public void Dispose()
        {
            _context = null;
        }

        public void Initialize(CompilerContext context)
        {
            _context = context;
        }

        public void Run()
        {
            foreach (var module in _context.CompileUnit.Modules)
            {
                DoCompileDocumentsToFile(module, _context);
            }
        }

        private void DoCompileDocumentsToFile(Module module, CompilerContext context)
        {
            Directory.CreateDirectory(context.Parameters.OutputDirectory);

            var visitor = new CompilingToFileVisitor(context);
            visitor.OnModule(module);
        }
    }
}
