#!/usr/bin/perl

  use Net::DNS;
  my $resolver = new Net::DNS::Resolver();

  my %config = ( 'server', '8.8.8.8',
                 'hostname', 'www.runscope.com' ); 


  $resolver->tcp_timeout(10);
  $resolver->udp_timeout(10);
  $resolver->nameservers( $config{'server'}  );
  $resolver->force_v4(1);
  $reply = $resolver->search( $config{'hostname'} );

  print "Content-type: application/json\n";

  if ($reply) {
    foreach my $rr ($reply->answer) {
      next unless $rr->type eq "A";
      my $ipa = $rr->address;
      print "Status: 200 OK\n\n";
      print "{\"status\": \"Connection successful\",\"response\":\"$ipa\"}";
     
    }
  } else {
      print "Status: 503 Service unavailable\n\n";
      print "{\"status\": \"Unable to connect\"}";
  }
