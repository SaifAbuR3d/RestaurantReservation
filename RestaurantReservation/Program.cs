﻿using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

string connectionString = configuration.GetSection("constr").Value;

