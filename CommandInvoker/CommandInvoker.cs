using CommandInvokerInterfaces;
using System;
using System.Collections.Concurrent;
using Logger;

namespace CommandInvoker
{
    public class CommandInvoker : ICommandInvoker
    {
        /// <summary>
        /// The Command queue
        /// </summary>
        public ConcurrentQueue<ICommand> Queue { get; set; }

        /// <summary>
        /// The undo stack, for reversing commands
        /// </summary>
        public ConcurrentStack<ICommand> UndoStack { get; set; }

        /// <summary>
        /// Redo stack for redo'ing the undo
        /// </summary>
        public ConcurrentStack<ICommand> RedoStack { get; set; }

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="command"></param>
        public void Invoke(ICommand command)
        {
            Queue.Enqueue(command);

            Process(Queue);
        }

        /// <summary>
        /// Method to process the queue
        /// </summary>
        /// <param name=""></param>
        private void Process(ConcurrentQueue<ICommand> CommandQueue)
        {
            if(CommandQueue.TryDequeue(out ICommand command))
            {
                command.Execute();
                AddToUndo(command);
            }
            else
            {
                Logger.Logger.Log(LogLevel.Error, "Failed to Execute the command");
            }
        }

        /// <summary>
        /// Add to the Undo stack
        /// </summary>
        /// <returns></returns>
        private void AddToUndo(ICommand Command)
        {
            UndoStack.Push(Command);
        }

        /// <summary>
        /// Add to the Redo stack
        /// </summary>
        /// <returns></returns>
        private void AddToRedo(ICommand Command)
        {
            RedoStack.Push(Command);
        }
    }
}
