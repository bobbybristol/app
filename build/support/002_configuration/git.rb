configs ={
  :git => {
    :user => "20120123orlando",
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'app' 
  }
}
configatron.configure_from_hash(configs)
