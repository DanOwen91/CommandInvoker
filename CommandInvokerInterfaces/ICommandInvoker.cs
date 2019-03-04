using System;
using System.Collections.Concurrent;

namespace CommandInvokerInterfaces
{
    public interface ICommandInvoker
    {
        /// <summary>
        /// The Command queue
        /// </summary>
        ConcurrentQueue<ICommand> Queue { get; set; }

        /// <summary>
        /// The undo stack, for reversing commands
        /// </summary>
        ConcurrentStack<ICommand> UndoStack {get; set;}

        /// <summary>
        /// Redo stack for redo'ing the undo
        /// </summary>
        ConcurrentStack<ICommand> RedoStack { get; set; }

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="command"></param>
        void Invoke(ICommand command);

    }
}
