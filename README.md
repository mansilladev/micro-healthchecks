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


License
-------
See LICENSE file in repo.
