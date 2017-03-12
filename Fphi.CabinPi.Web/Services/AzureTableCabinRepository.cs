using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fphi.CabinPi.Web.Models;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Fphi.CabinPi.Web.Services
{
    public class AzureTableCabinRepository : ICabinRepository
    {
        private AppOptions _options;

        public AzureTableCabinRepository(IOptions<AppOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public void AddCurrentSensorValue(SensorValue newValue)
        {
            CloudTable table = GetCloudTable("SensorValues");

            TableOperation insertOperation = TableOperation.Insert(newValue);
            table.Execute(insertOperation);
        }

        public void AddSensorData(ReadingAggregate data)
        {
            CloudTable table = GetCloudTable("SensorReadings");

            TableOperation retrieveOperation = TableOperation.Retrieve<ReadingAggregate>(data.PartitionKey, data.RowKey);
            var result = table.Execute(retrieveOperation);
            if (result.Result != null)
            {
                var oldData = result.Result as ReadingAggregate;
                oldData.Average = ((oldData.Average * oldData.Samples) + (data.Average * data.Samples)) / (oldData.Samples + data.Samples);
                oldData.Max = Math.Max(oldData.Max, data.Max);
                oldData.Min = Math.Min(oldData.Min, data.Min);

                oldData.Samples += data.Samples;

                TableOperation updateOperation = TableOperation.Replace(oldData);
                table.Execute(updateOperation);
            }
            else
            {
                TableOperation insertOperation = TableOperation.Insert(data);
                table.Execute(insertOperation);
            }
        }

        private CloudTable GetCloudTable(string tableName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_options.AzureTableConnectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference(tableName);
            return table;
        }

        public List<SensorValue> GetCurrentSensorValues()
        {
            CloudTable table = GetCloudTable("SensorValues");
            TableQuery<SensorValue> query = new TableQuery<SensorValue>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Current"));
            return table.ExecuteQuery(query).ToList();

        }

        public void UpdateCurrentSensorValue(SensorValue currentValue)
        {
            CloudTable table = GetCloudTable("SensorValues");
            var updateOperation = TableOperation.Replace(currentValue);
            table.Execute(updateOperation);
        }

        public List<ReadingAggregate> GetSensorData(string sensorName)
        {
            CloudTable table = GetCloudTable("SensorReadings");
            TableQuery<ReadingAggregate> query = new TableQuery<ReadingAggregate>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, sensorName));
            return table.ExecuteQuery(query).ToList();
        }
    }
}
