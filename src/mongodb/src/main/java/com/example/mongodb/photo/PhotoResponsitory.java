package com.example.mongodb.photo;

import org.springframework.data.mongodb.repository.MongoRepository;

import java.util.List;

public interface PhotoResponsitory extends MongoRepository<Photo,String> {
    List<Photo> findByIdUser(String id);
}
