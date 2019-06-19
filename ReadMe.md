Solution is created in Visual Studio 2013.

Solution structure:

1) DataProcessor project contains logic for input data processing.
2) SerkoWebApi project is a REST service.
3) ClientWinApp project contains test application.


How to test:
1) Run webapi on IIS.
2) Change SerkoWebApiUrl setting in ClientWinApp project's App.config file to point to deployed webapi url, for example:
	<add key="SerkoWebApiUrl" value="http://localhost:13917/api/"/>
3) Run ClientWinApp.exe. Enter email content into "Input data" text area, press "Test" button, see output in "Result" text area.	


Explanation: 
Tried to implement data processing in more generic way. So, potentially, it can be used for processing email text with different "xml"-islanded content. 
	For that purpose you need to implement:
		- new class (see example in ExpenseClaimParser in DataProcessor project). 
		- define new class which takes deserialized xml-data (see example in ExpenseClaim in DataProcessor project)
		- feed two aforementioned classes to TextDataProcessor object and invoke Process(...) method on it (see example in ExpenseController.ProcessEmailText() 	method in SerkoWebApi project)

Assumptions:
1) GST calculating method is simple: it takes 15% from total and rounds gst value using Math.Round(...).