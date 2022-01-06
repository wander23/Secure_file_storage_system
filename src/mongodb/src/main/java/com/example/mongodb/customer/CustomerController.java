package com.example.mongodb.customer;


import com.example.mongodb.model.ResponeObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Objects;
import java.util.Optional;

@RestController
@RequestMapping("/customers")
public class CustomerController {
    @Autowired
    private CustomerResponsitory customerResponsitory;

    @GetMapping("")
    ResponseEntity<ResponeObject> findall() {
        List<Customer> findall = customerResponsitory.findAll();
        return ResponseEntity.status(HttpStatus.OK).body(
                new ResponeObject("ok", "data", findall)
        );

    }

    @GetMapping("/{id}")
    ResponseEntity<ResponeObject> findone(@PathVariable String id) {
        Optional<Customer> findone = customerResponsitory.findById(id);
        return ResponseEntity.status(HttpStatus.OK).body(
                new ResponeObject("ok", "data", findone)
        );
    }

    @PostMapping("/{id}")
    ResponseEntity<ResponeObject> checkId(@PathVariable String id) {
        Optional<Customer> foundID = customerResponsitory.findById(id);
        return foundID.isPresent() ?
                ResponseEntity.status(HttpStatus.NOT_IMPLEMENTED).body(
                        new ResponeObject("failed", "ID already taken", "")
                ) :
                ResponseEntity.status(HttpStatus.OK).body(
                        new ResponeObject("ok", "You can take this ID", "")
                );
    }

    @PostMapping("/register")
    ResponseEntity<ResponeObject> register(@RequestBody Customer newCustomer) {
        if (!Objects.equals(newCustomer.getUsername(), newCustomer.getUsername().replaceAll("\\s", ""))) {
            return ResponseEntity.status(HttpStatus.NOT_IMPLEMENTED).body(
                    new ResponeObject("username", "Invalid username", "")
            );
        }

        if (newCustomer.getPassword().length() < 6 || !Objects.equals(newCustomer.getPassword(), newCustomer.getPassword().replaceAll("\\s", ""))) {
            return ResponseEntity.status(HttpStatus.NOT_IMPLEMENTED).body(
                    new ResponeObject("password", "Invalid password", "")
            );
        }

        Optional<Customer> foundCustomer = customerResponsitory.findByUsername(newCustomer.getUsername());
        return foundCustomer.isPresent() ?
                ResponseEntity.status(HttpStatus.NOT_IMPLEMENTED).body(
                        new ResponeObject("failed", "Account already taken", "")
                ) :
                ResponseEntity.status(HttpStatus.OK).body(
                        new ResponeObject("ok", "Already create account", customerResponsitory.save(newCustomer))
                );
    }

    @PostMapping("/login")
    ResponseEntity<ResponeObject> login(@RequestBody Customer checkCustomer) {
        Optional<Customer> foundUsername = customerResponsitory.findByUsername(checkCustomer.getUsername());
        if (foundUsername.isEmpty()) {
            return ResponseEntity.status(HttpStatus.NOT_IMPLEMENTED).body(
                    new ResponeObject("failed", "Account doesnt exists", "")
            );
        }
        Optional<Customer> foundCustomer = customerResponsitory.findByUsernameAndAndPassword(checkCustomer.getUsername(), checkCustomer.getPassword());
        return foundCustomer.isPresent() ?
                ResponseEntity.status(HttpStatus.OK).body(
                        new ResponeObject("ok", "Successfully", foundCustomer)
                ) :
                ResponseEntity.status(HttpStatus.NOT_IMPLEMENTED).body(
                        new ResponeObject("failed", "Wrong password", "")
                );
    }

}
