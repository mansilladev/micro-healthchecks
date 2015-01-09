micro-healthchecks
==================

This is a sample collection of tiny web server scripts that perform health checks / pings on internal services. Each of these scripts has only one function -- to report whether or not they could connect to a service. Additionally, these scripts should have as few dependencies as possible. These serve as supporting examples of a blog post about creating micro health check API endpoints for services that your APIs depend on. The original blog post can be found here: https://blog.runscope.com/posts/build-a-health-check-api-for-services-underneath-your-api

The interface for these scripts is minimal. They're intended to be requested via HTTP GET on a web server that supports the script's language with no required inputs in the URI, headers or body.

If the test is successful, the HTTP response code is `200` -- otherwise, it's `503`. The response output is JSON and will be one of the two following responses:

```
{
 "status":"Connection successful"
}
```

or

```
{
 "status":"Unable to connect"
}
```



PHP
---
####MySQL > php/mysqlConnect.php
This script uses PHP's internal mysqli extension. A valid username and password is required. `$config['server]` includes hostname and port number (e.g. `127.0.0.1:3306`).

Python
------
####Redis > python/redisConnect.py
This script requires the well supported `redis-py` library ([GitHub link](https://github.com/andymccurdy/redis-py)), which is installable by pip, easy_install or from source. The server hostname (or IP), port and database number are required `config` parameters.

####MongoDB > python/mongoConnect.py
This script requires `PyMongo` ([link](http://api.mongodb.org/python/current/index.html)), which is installable by pip, easy_install or from source. The server URI is required. This does not try to connect to a specific database, nor is it using ping. It only attempts to establish a client connection.

Perl
------
####DNS > perl/dnsConnect.py
This script requires `Net::DNS` which is most easily installed using CPAN.

.Net
------
####MS SQL Server > dotnet/mssqlConnect.cs
This is a Web API Controller class that can be dropped into any ASP.NET Web API enabled project.  The server connection string parameters need to be supplied.


License
-------
See LICENSE file in repo.
