using System;
using System.Collections.Generic;
using System.Text;

namespace CommandInvokerInterfaces
{
    public interface ICommand
    {
        /// <summary>
        /// Name of the command
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// An execute method
        /// </summary>
        void Execute();

    }
}
