﻿using LINQtoCSV;
using System;
using System.Text;

namespace Honey.DAL.Entity
{
    public class Subscriber : Base
    {
        [CsvColumn(FieldIndex = 2, Name = "Email Address")]
        public string EmailAddress { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "Is Active")]
        public bool IsActive { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "Updated At")]
        public DateTime UpdatedAt { get; set; }

        public static string GetSubscriberKey(Subscriber subscriber)
        {
            var bytes = Encoding.UTF8.GetBytes(
                string.Format("{0}~{1}", subscriber.EmailAddress, subscriber.Id));
            return Convert.ToBase64String(bytes);
        }

        public static Subscriber GetSubscriberFromKey(string key)
        {
            string subString = key.Substring(1);
            var bytes = Convert.FromBase64String(subString);
            var pair = Encoding.UTF8.GetString(bytes);
            var pairArr = pair.Split(new char[] { '~' });
            if (pairArr == null || pairArr.Length != 2)
            {
                return new Subscriber();
            }
            return new Subscriber
            {
                Id = int.Parse(pairArr[1]),
                EmailAddress = pairArr[0]
            };
        }
    }
}