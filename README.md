micro-healthchecks
==================

This is a sample collection of tiny web server scripts that perform health checks / pings on internal services. Each of these scripts has only one function -- to report whether or not they could connect to a service. Additionally, these scripts should have as few dependencies as possible.

The interface for these scripts is minimal. They're intended to be requested via HTTP GET on a web server that supports the script's language with no required inputs in the URI, headers or body.

The output is JSON, and one of the two following responses:

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

License
-------
See LICENSE file in repo.
