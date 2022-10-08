using System.Globalization;
using CsvHelper;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Application.TodoLists.Queries.ExportTodos;
using SuddanApplication.Infrastructure.Files.Maps;

namespace SuddanApplication.Infrastructure.Files;
public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
