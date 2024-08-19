- add all the CRUD to all entities and respective use cases, validators, exception messages, requests and responses where applicable 
    - Donors
        1) GetAll
        2) GetById
        3) DeleteById
        4) ChangeStatusById
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
- when you create the CRUDs for payments and pledges you gotta check if the linking db's thingy in the dbcontext is working
- Enum of ActivityStatus
    status can be an integer
- Error for donor, payment or pledge if already in the system 
    - maybe item below is the solution
    - conflictException
- find a way to run the db script only having a MySQL instance running (probably some mechanism to edit the connectionString)
- Add entity filtering for all API controllers
- change from Guid to INT primary key system handled by MySQL
- We need to decide if we'll go the class or resource route for exception messages