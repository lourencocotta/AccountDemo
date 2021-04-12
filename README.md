# AccountDemo

## Technologies/Patterns (positives characteristic)
- .NET Core 5.0
- ASP .NET Core 5.0
- Swagger (Documentation)
- Entity Framework Core (SQL lite)
- AutoMapper
- Model-View-Controller (MVC)
- SOLID

Layered Architecture
---

![image](https://user-images.githubusercontent.com/5546152/114326729-80568a00-9b0c-11eb-9ae2-56102421ec2c.png)


Usage instructions
---

- Clone this repository;
- Open solution in Visual Studio (this sample was made using Visual Studio 2019);
- Run the project.

Seed
---
Data is inputted after database creation
 ```c#
 protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            var account = new Account
            {
                Id =1 , AccountCode="code 1"
            };
            modelBuilder.Entity<Account>().HasData(account);

            var customers = new List<Transaction>
            {
                new Transaction { TransactionId = Guid.NewGuid(), Description= "Test 1" , TransactionDate= DateTime.Now, Amount= (decimal)100, FromPayee="from test 1", AccountId = 1 },
                new Transaction { TransactionId = Guid.NewGuid(), Description= "Test 2" , TransactionDate= DateTime.Now, Amount= (decimal)-50, FromPayee="from test 2", AccountId = 1 },
            };

            modelBuilder.Entity<Transaction>().HasData(customers);
        }
  ```

How to get account balance
---

> Use "code 1" as parameter for Account code.


![image](https://user-images.githubusercontent.com/5546152/114326395-f35f0100-9b0a-11eb-92e3-d233cbde7006.png)

![image](https://user-images.githubusercontent.com/5546152/114326435-26a19000-9b0b-11eb-83af-acff1997ae97.png)




