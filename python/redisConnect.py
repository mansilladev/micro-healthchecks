#!/usr/local/bin/python

import redis
from redis import ConnectionError

config = { 'server': 'localhost', 'port': '6379', 'db': '0'}

print 'Content-type: application/json'
r_server = redis.StrictRedis(host=config['server'], port=config['port'], db=config['db'])

try:
    r_server.ping()
    print 'Status: 200 OK'
    print
    print '{"status":"Connection successful"}'

except ConnectionError:
    print 'Status: 503 Service Unavailable'
    print
    print '{"status":"Unable to connect"}'
    exit(0)
