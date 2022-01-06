package com.example.mongodb.photo;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

@Document(collection = "photos")
public class Photo {
    @Id
    private String id;

    private String urlImage;

    private String idUser;

    public Photo() {
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getUrlImage() {
        return urlImage;
    }

    public void setUrlImage(String urlImage) {
        this.urlImage = urlImage;
    }

    public String getIdUser() {
        return idUser;
    }

    public void setIdUser(String idUser) {
        this.idUser = idUser;
    }

    @Override
    public String toString() {
        return "Photo{" +
                "id='" + id + '\'' +
                ", urlImage='" + urlImage + '\'' +
                ", idUser='" + idUser + '\'' +
                '}';
    }

    public Photo(String id, String urlImage, String idUser) {
        this.id = id;
        this.urlImage = urlImage;
        this.idUser = idUser;
    }
}