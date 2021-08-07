namespace Motes.Persistence
{
    public class DbInitializer
    {
        /// <summary>
        /// Проверка наличия базы данных и создание её в случаи отсутствия
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
