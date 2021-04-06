CREATE DATABASE Company

CREATE TABLE HeadOffice(
	hid int not null PRIMARY KEY,
	name nvarchar(30) not null UNIQUE,
	city nvarchar(30),
	country nvarchar(30),
	address nvarchar(30),
	phone nvarchar(30),
	director nvarchar(30)
)

CREATE TABLE Project(
	pid int not null PRIMARY KEY,
	title nvarchar(30),
	startDate datetime,
	endDate datetime,
	budget money,
	manager nvarchar(30),
	hid int FOREIGN KEY REFERENCES HeadOffice(hid)
)

CREATE TABLE Project_Detail(
	pid int FOREIGN KEY REFERENCES Project(pid),
	operation nvarchar(30),
	city nvarchar(30),
	country nvarchar(30),
	ppl int
)


CREATE DATABASE LendingCompany

CREATE TABLE Loan(
	loadId int not null PRIMARY KEY,
	amount money,
	deadline datetime,
	interest_rate decimal(5,2),
	purpose nvarchar(30),
)

CREATE TABLE Invest(
	investId int not null PRIMARY KEY,
	loanid int FOREIGN KEY REFERENCES Loan(loadId),
	amount money
)


CREATE TABLE Lenders(
	lid int not null PRIMARY KEY,
	name nvarchar(30),
	amount money,
	investId int FOREIGN KEY REFERENCES Invest(investId),
)

CREATE TABLE Borrowers(
	bid int not null PRIMARY KEY,
	name nvarchar(30),
	risk int,
	loanCode int FOREIGN KEY REFERENCES Loan(loadId),
)

CREATE DATABASE Restaurant

CREATE TABLE Category(
	cid int not null PRIMARY KEY,
	name nvarchar(30),
	description nvarchar(30),
	employee nvarchar(30),
)

CREATE TABLE Course(
	courseId int not null PRIMARY KEY,
	name nvarchar(30),
	description nvarchar(30),
	photo image,
	price money,
	cid int FOREIGN KEY REFERENCES Category(cid),
)

CREATE TABLE Recipes(
	rid int not null PRIMARY KEY,
	ingredients nvarchar(30),
	amount float,
	units nvarchar(30),
	current_amount_in_store float,
	courseID int FOREIGN KEY REFERENCES Course(courseID),
)

