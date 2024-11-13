using Calculate.Loggers;
using Calculate.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class FileStorage
{
    private ILogger _logger;
    private string _filePath;

    public FileStorage(ILogger logger, string filePath)
    {
        _logger = logger;
        _filePath = filePath;
    }

    // Синхронный метод для запуска асинхронной задачи сохранения
    public async Task Save(List<double> list)
    {
        try
        {
            // Запуск асинхронной задачи для сохранения в отдельном потоке

            try
            {
                // Сериализация списка в JSON
                var json = JsonSerializer.Serialize(list);

                // Запись JSON в файл асинхронно
                using (var writer = new StreamWriter(_filePath, false))
                {
                    await writer.WriteAsync(json);
                }

                await File.WriteAllTextAsync(json, _filePath);
            }

            catch (Exception ex) // 
            {
                // Обработка исключений внутри асинхронной задачи
                _logger.Log("An error occurred while saving the list asynchronously: " + ex.Message);
            }
           
        }
        catch (Exception ex)
        {
            _logger.Log("An error occurred while initiating the save process: " + ex.Message);
        }
    }


    // Метод для загрузки списка из файла
    public async Task<List<double>> Load()
    {
        try
        {
            // Проверка существования файла
            if (!File.Exists(_filePath))
        {
                _logger.Log("File not found.");
                return  new List<double>();
            }

            // Чтение JSON из файла
            string json = await File.ReadAllTextAsync(_filePath);

            // Десериализация списка из JSON
            return JsonSerializer.Deserialize<List<double>>(json);
        }
        catch (Exception ex)
        {
            _logger.Log("An error occurred while loading the list: " + ex.Message);
            return new List<double>();
        }
    }
}
