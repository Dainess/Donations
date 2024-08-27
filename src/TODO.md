- add all the CRUD to all entities and respective use cases, validators, exception messages, requests and responses where applicable 
    - Pledges
        1) Resgister
        2) GetAll
        3) GetById
        4) DeleteById
        5) AllPaymentsOfPledgeById
    - Payments
        1) Resgister
        2) GetAll
        3) GetById
        4) DeleteById
        5) AllPledgesOfPaymentById
- changelog must be created
    - Enum of Changelog
- when you create the CRUDs for payments and pledges you gotta check if the linking db's thingy in the dbcontext is working
    - check if in getbyid of donor if the payments and pledges show up
- Error for donor, payment or pledge if already in the system 
    - maybe item below is the solution
    - conflictException, check how it's used in NLWUnite
- Full json for payments, pledges?
- find a way to run the db script only having a MySQL instance running (probably some mechanism to edit the connectionString)
- upload to github
- Add entity filtering for all API controllers
- change from Guid to INT primary key system handled by MySQL
    - this may be the root cause of trying to add row to child table through parent table not working 
- We need to decide if we'll go the class or resource route for exception messages
- Where's all the asyncs?