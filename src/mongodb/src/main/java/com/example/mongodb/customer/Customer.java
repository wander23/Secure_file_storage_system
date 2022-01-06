package com.example.mongodb.customer;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;


@Document
public class Customer {
    @Id
    private String ID;
    private String username;
    private String fullname;
    private int n;
    private int e;
    private String password;

    public Customer() {
    }

    @Override
    public String toString() {
        return "Customer{" +
                "ID=" + ID +
                ", username='" + username + '\'' +
                ", fullname='" + fullname + '\'' +
                ", n=" + n +
                ", e=" + e +
                ", password='" + password + '\'' +
                '}';
    }

    public Customer(String ID, String username, String fullname, int n, int e, String password) {
        this.ID = ID;
        this.username = username;
        this.fullname = fullname;
        this.n = n;
        this.e = e;
        this.password = password;
    }

    public String getID() {
        return ID;
    }

    public void setID(String ID) {
        this.ID = ID;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getFullname() {
        return fullname;
    }

    public void setFullname(String fullname) {
        this.fullname = fullname;
    }

    public int getN() {
        return n;
    }

    public void setN(int n) {
        this.n = n;
    }

    public int getE() {
        return e;
    }

    public void setE(int e) {
        this.e = e;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
