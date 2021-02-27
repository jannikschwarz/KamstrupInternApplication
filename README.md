# KamstrupInternApplication
A distributed application for the internship at Kamstrup. By Jannik Schwarz-Wolf 
The application is setup with a Webpage Blazor Server that handles the UI and sends them via a Rest Call to the WebApi. The Webapi contains both the Restfull web application and
the database containing the websites information. 


# Deploying indiviual containers
Replace the x in the port with the port of the service
```
docker build -t app -f Dockerfile .
docker run -d -p 500x:500x --name myapp app:latest
```

# Composing the services
```
docker-compose up --build
``` 
