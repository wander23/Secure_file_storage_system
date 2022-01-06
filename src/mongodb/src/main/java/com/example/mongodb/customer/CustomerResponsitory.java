package com.example.mongodb.customer;

import org.springframework.data.mongodb.repository.MongoRepository;

import java.util.Optional;

public interface CustomerResponsitory extends MongoRepository<Customer,String> {
    Optional<Customer> findByUsernameAndAndPassword(String username, String password);
    Optional<Customer> findByUsername(String username);
}
