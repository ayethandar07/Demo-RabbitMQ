<h1> RabbitMQ Test Project </h1>
<p> This project demonstrates how to use RabbitMQ with a .NET 8 Web API. It includes functionality for sending and receiving messages using RabbitMQ. This README provides an overview of the project, setup instructions, and usage guidelines.</p>

<h3> Project Overview </h3>
<p>The project includes:
<ul>
  <li> <strong>RabbitMQService: </strong>  A service that manages RabbitMQ connections and channels.</li>
  <li><strong> MessageProducer: </strong> A class responsible for sending messages to a RabbitMQ queue.</li>
  <li> <strong>MessageConsumer: </strong> A class that consumes messages from a RabbitMQ queue.</li>
  <li> <strong>ConsumerBackgroundService: </strong> A background service that starts the message consumer when the application starts.</li>
</ul>
</p>

<h3> Prerequisites </h3>
<ul>
  <li> .NET 8 SDK <a href="https://dotnet.microsoft.com/download"> https://dotnet.microsoft.com/download </a> </li>
  <li>  Docker <a href="https://www.docker.com/products/docker-desktop"> https://www.docker.com/products/docker-desktop </a></li>
</ul>

<h3> Clone the Repository </h3><p></p>
<div class="codehilite">
<pre><code> 
   git clone https://github.com/ayethandar07/Demo-RabbitMQ.git
</code></pre>
</div>

<h3>Configure RabbitMQ</h3>
<h5>Using Docker</h5>
<p>Run RabbitMQ with the management plugin using Docker:</p><p></p>
<div class="codehilite">
<pre><code> 
   docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management
</code></pre>
</div>

<h3>Configure Application Settings</h3>
<p>Update appsettings.json with your RabbitMQ settings:</p><p></p>
<div class="codehilite">
<pre><code> 
   {
        "RabbitMQ": {
        "HostName": "localhost",
        "UserName": "guest",
        "Password": "guest",
        "VirtualHost": "/"
        }
  }
</code></pre>
</div>

<h3> Testing </h3>
<ul>
  <li><strong>MessageProducer:</strong> Use the MessageProducer class to send messages to a RabbitMQ queue.</li>
  <li><strong>MessageConsumer:</strong> The ConsumerBackgroundService automatically starts the MessageConsumer when the application starts. You can view consumed messages in the console.</li>
</ul>
<p>To send a message, you can use the MessageProducer directly from your application or API endpoints, depending on your setup.</p>

<h3> Contact </h3>
<p>For questions or feedback, please contact <a href="mailto:athandar1998@gmail.com">athandar1998@gmail.com</a>.</p>
