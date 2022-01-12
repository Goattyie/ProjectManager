using ProjectManager.Abstractions.Models;
using ProjectManager.Bll.Models;

namespace ProjectManager.Bll.TypeEx
{
    internal static class Extentions
    {
        public static IEnumerable<TaskDTO> AsTaskDTOEnumerable(this IEnumerable<ITask> list)
        {
            return list.Select(x => new TaskDTO(x));
        }

        public static IEnumerable<ProjectDTO> AsProjectDTOEnumerable(this IEnumerable<IProject> list)
        {
            return list.Select(x => new ProjectDTO(x));
        }
    }
}
