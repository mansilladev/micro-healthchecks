#!/usr/local/bin/python

import pymongo
from pymongo import MongoClient

print 'Content-type: application/json'
try:
    m_client = MongoClient('mongodb://localhost:27017/')
    print 'Status: 200 OK'
    print
    print '{"status":"Connection successful"}'
except:
    print 'Status: 503 Service Unavailable'
    print
    print '{"status":"Unable to connect"}'
    exit(0)
