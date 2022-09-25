using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AwsCdkEksCluster
{
    sealed class Program
    {
        private VpcStack _vpcStack;
        //private PipelineStack _pipelineStack;
        private EksStack _eksStack;
        private App _app;
        public static void Main(string[] args)
        {
            string stackName = "EksID";
            bool isCloud9 = false;
            Program program = CreateProgram(stackName,isCloud9);
            program.Synth();
        }

        private static Program CreateProgram(string stackName,bool isCloud9)
        {
            Program program = new Program();
            program._app = new App();
            program._vpcStack = new VpcStack(program._app, $"{stackName}-base", CreateStackProps());
            program._eksStack = new EksStack(program._app, $"{stackName}-eks", program._vpcStack.Vpc , isCloud9, CreateStackProps());
            //program._pipelineStack = new PipelineStack(program._app, $"{stackName}-pipeline", CreateStackProps());
            return program;
        }

        private void Synth()
        {
            _app.Synth();
        }

        private static StackProps CreateStackProps()
        {
            return new StackProps
            {
               
            };
        }
    }
}