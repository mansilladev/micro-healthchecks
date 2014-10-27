<?php

  $config = [
     "server"     => "127.0.0.1:3306",
     "username"   => "root",
     "password"   => ""  
  ];

  header('Content-type: application/json');

  $link = new mysqli($config['server'],$config['username'],$config['password']);

  if ($link->connect_errno) {
    http_response_code(503);
    echo('{ "status": "Unable to connect" }');
  }
  else {
    http_response_code(200);
    echo('{ "status": "Connection successful." }');
  }
?>
