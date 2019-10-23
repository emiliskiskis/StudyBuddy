# StudyBuddy

## Backend

* Backend IP address: http://www.buddiesofstudy.tk/ (port 80)
* Content type for request and response will always be JSON (application/json).
* GET requests may not contain a request body and will contain a response body describing the entity or other information as mentioned per endpoint.
* POST, PUT, PATCH requests must contain a request body and will contain a response body fully describing the created/updated entity or other information as mentioned per endpoint.
* DELETE requests may not contain a request body and will contain a response body fully describing the entity that was deleted.
* Please report issues with the back-end. It's likely to be faulty.

### Backend API endpoints
  * `/api/users`
  
      User entity model:
      ```      
      {
        "username": Username,
        "password": Password hashed with salt,
        "salt": Salt used with password hashing,
        "firstName": First name,
        "lastName": Last name,
        "email": Email address,
        "chats": List of chat ids user is participating in (read-only)
      }
      ```
    * `POST /` - add new user  (returns added user)
    * `GET /` - get all users (returns their usernames and names)
    * `GET /{username}` - get user (password and salt will not be provided)
    * `GET /{username}/salt` - get user salt
    * `PUT /{username}` - update user (returns updated user without chats)
    * `PATCH /{username}` - patch user info partially (returns updated user without chats)
    * `DELETE /{username}` - delete user (returns deleted user without chats)
    
    On password change both password and salt fields have to be updated.
  * `api/login`
  
    Login entity model:
    ```
    {
      "username": Username of user,
      "password": Password of user hashed with salt
    }
    ```
    * `POST /` - request to login to server (200 OK if logged in)
  * `api/chat`
  
    Group request model:
    ```
    {
      "username": Username of user who's connecting,
      "connectTo": Username of user to connect to
    }
    ```
    
    Group response model:
    ```
    {
      "groupName": Name of group, a GUID string
    }
    ```
    * `POST /` - create group and get its name; if group between exactly two users already exists, get its name
