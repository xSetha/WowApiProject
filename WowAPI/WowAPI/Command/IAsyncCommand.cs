using System.Threading.Tasks;
using System.Windows.Input;

namespace WowAPI.Command
{
    /// <summary>
    /// Async version of the <see cref="ICommand"/> interface 
    /// </summary>
    public interface IAsyncCommand : ICommand
    {
        /// <summary>
        /// Executes the code in an async way
        /// </summary>
        /// <returns></returns>
        Task ExecuteAsync(object? param);
    }
}
