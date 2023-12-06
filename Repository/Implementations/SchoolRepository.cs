using Microsoft.EntityFrameworkCore;
using Npgsql;
using Repository.Data;
using Repository.Interfaces;
using System.Linq.Expressions;

namespace Repository.Implementations
{
    public class SchoolRepository<T> : ISchoolRepository<T> where T : class
    {
        private readonly SchoolContext _context;
        private DbSet<T> _entity;

        public SchoolRepository(SchoolContext testContext)
        {
            _context = testContext;
            _entity = _context.Set<T>();
        }

        public int BulkInsert(List<T> entities)
        {
            var output = 0;

            using (var connection = new NpgsqlConnection(""))
            {
                connection.Open();

                // Create a temporary table to hold the data
                using (var command = new NpgsqlCommand("CREATE TEMPORARY TABLE temp_table (id INT, name TEXT)", connection))
                {
                    command.ExecuteNonQuery();
                }

                // Copy data to the temporary table using the COPY command
                //using (var writer = connection.BeginBinaryImport("COPY temp_table (id, name) FROM STDIN (FORMAT BINARY)"))
                //{
                //    foreach (var item in entities)
                //    {
                //        writer.StartRow();
                //        writer.Write(item.Id, NpgsqlDbType.Integer);
                //        writer.Write(item.Name, NpgsqlDbType.Text);
                //    }
                //    writer.Complete();
                //}

                // Merge the data from the temporary table into the actual table
                using (var command = new NpgsqlCommand("INSERT INTO actual_table SELECT * FROM temp_table", connection))
                {
                    output = command.ExecuteNonQuery();
                }

                return 0;
            }
        }

        public int Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entity.Add(entity);

            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entity.Remove(entity);

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = _entity.Find(id);

            if(entity == null)
            {
                return 0;
            }

            entity.GetType().GetProperty("IsActive").SetValue(entity, false);
            entity.GetType().GetProperty("ModifiedDate").SetValue(entity, DateTime.Now);

            _context.Attach<T>(entity);

            return _context.SaveChanges();

            /* === Code below is updating a record without retrieving it ===
            var entity = (T)Activator.CreateInstance(typeof(T));
            entity.GetType().GetProperty("Id").SetValue(entity, id);

            _context.Attach<T>(entity);

            //  need to change the value to true first
            //  in order to apply new value for bool data types
            _context.Entry<T>(entity).Property("IsActive").CurrentValue = true;
            _context.Entry<T>(entity).Property("IsActive").CurrentValue = false;
            _context.Entry<T>(entity).Property("ModifiedDate").CurrentValue = DateTime.Now;

            return _context.SaveChanges();
            */
        }

        public T Read(int id)
        {
            return _entity.Find(id);
        }

        public IList<T> Read(Expression<Func<T, bool>> predicate)
        {
            return _entity.Where(predicate).ToList();
        }

        public int Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var result = _entity.Find(
                entity.GetType().GetProperty("Id").GetValue(entity));

            if (result == null)
            {
                return 0;
            }

            return _context.SaveChanges();
        }
    }
}
