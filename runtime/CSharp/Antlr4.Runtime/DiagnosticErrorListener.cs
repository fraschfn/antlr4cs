/*
 * [The "BSD license"]
 *  Copyright (c) 2013 Terence Parr
 *  Copyright (c) 2013 Sam Harwell
 *  All rights reserved.
 *
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions
 *  are met:
 *
 *  1. Redistributions of source code must retain the above copyright
 *     notice, this list of conditions and the following disclaimer.
 *  2. Redistributions in binary form must reproduce the above copyright
 *     notice, this list of conditions and the following disclaimer in the
 *     documentation and/or other materials provided with the distribution.
 *  3. The name of the author may not be used to endorse or promote products
 *     derived from this software without specific prior written permission.
 *
 *  THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 *  IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 *  OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 *  IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 *  INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 *  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 *  DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 *  THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 *  (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 *  THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Dfa;
using Antlr4.Runtime.Misc;
using Sharpen;

namespace Antlr4.Runtime
{
    public class DiagnosticErrorListener : BaseErrorListener
    {
        public override void ReportAmbiguity(Parser recognizer, DFA dfa, int startIndex, 
            int stopIndex, BitSet ambigAlts, ATNConfigSet configs)
        {
            string format = "reportAmbiguity d={0}: ambigAlts={1}, input='{2}'";
            recognizer.NotifyErrorListeners(string.Format(format, GetDecisionDescription(recognizer
                , dfa.decision), ambigAlts, ((ITokenStream)recognizer.InputStream).GetText(Interval
                .Of(startIndex, stopIndex))));
        }

        public override void ReportAttemptingFullContext(Parser recognizer, DFA dfa, int 
            startIndex, int stopIndex, SimulatorState initialState)
        {
            string format = "reportAttemptingFullContext d={0}, input='{1}'";
            recognizer.NotifyErrorListeners(string.Format(format, GetDecisionDescription(recognizer
                , dfa.decision), ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex
                , stopIndex))));
        }

        public override void ReportContextSensitivity(Parser recognizer, DFA dfa, int startIndex
            , int stopIndex, SimulatorState acceptState)
        {
            string format = "reportContextSensitivity d={0}, input='{1}'";
            recognizer.NotifyErrorListeners(string.Format(format, GetDecisionDescription(recognizer
                , dfa.decision), ((ITokenStream)recognizer.InputStream).GetText(Interval.Of(startIndex
                , stopIndex))));
        }

        protected internal virtual string GetDecisionDescription(Parser recognizer, int decision
            )
        {
            return decision.ToString();
        }
    }
}
