Frontend: (Recommended time 2 hours)
Get the data from a given API and display it on a web page. Recommended tools for frontend are Angular or React, however, you can use any other tool of your choice.
API: http://universities.hipolabs.com/search?country={country_name} 
The API will take the country name as input and will return all universities of that country in JSON format. 
Example: http://universities.hipolabs.com/search?country=Pakistan
[{"domains": ["itu.edu.pk"], "name": "Information Technology University, Lahore", "alpha_two_code": "PK", "web_pages": ["https://itu.edu.pk/"], "state-province": "Punjab", "country": "Pakistan"}, {"domains": ["abasyn.edu.pk"], "name": "Abasyn University Peshawar", "alpha_two_code": "PK", "web_pages": ["http://www.abasyn.edu.pk/"], "state-province": "Khyber Pakhtunkhwa", "country": "Pakistan"}, {"domains": ["aiou.edu.pk"], "name": "Allama Iqbal Open University", "alpha_two_code": "PK", "web_pages": ["http://www.aiou.edu.pk/"], "state-province": null, "country": "Pakistan"}]
Web page should be as described below:
Country Name:  

List of Universities in Pakistan
+	University Name: Information Technology University, Lahore
	Domains: itu.edu.pk
	Country Code: PK
	Web Sites: https://itu.edu.pk/
	State / Province: Punjab
	Country: Pakistan
+ 	Abasyn University Peshawar
+	Allama Iqbal Open University
Instructions: 
1.	Take the country name as input and pass to the API
2.	Display the data in format given above
3.	By clicking on the university name, open the details of that university in a new page
4.	+ sign will be a toggle. It will expand and collapse on clicks
5.	By clicking on the web site, open the university website in a new tab

Backend: (Recommended time 4 hours)
Write APIs in .Net to save, retrieve and update the data in the database of your choice. This is the data that you have obtained in the frontend application. Write following APIs:
1.	API to save country name and data of universities in database
2.	API to retrieve data of universities based on country name
3.	API to update the data of a university based on country name and university ID
Code Submission:
1.	Create a public git repository
2.	Push your code in that repository
3.	Share link of repository
Plus:
It will be a plus if you host the application on your server
