# 🌌 APOD
APOD api가 갱신될 때마다 APOD 정보를 블로그 형식으로 자동 업로드하는 웹사이트입니다. 이용자들은 각 게시글에 댓글을 달며 개인간의 의견을 주고받을 수 있습니다.
<br />
<br />

# 🌏 왜 만들었나요?
초등학생 시절 시골에서 살았을 때 학교와 태권도 도장에서 폭력을 당해 극심한 스트레스를 받았던적이 있습니다.
그럴때마다 저는 밤하늘에 밝게 빛나는 별들을 보며 스트레스를 풀곤 했습니다.
그때부터 별에 대한 관심이 생겨 혼자서 우주와 관련된 책들을 읽고 별들을 관측하며 우주에 대한 흥미를 쌓아갔습니다.
그러다 우연히 NASA애서 제공하는 APOD(Astronomy Picture of the Day)라는 api를 발견하였고, 이 api가 매일 우주사진과 그 우주사진에 대한 정보를 제공한다는 것을 알게 되었습니다.
저는 이 api를 보며 '매일 올라오는 우주에 대한 정보를 블로그 형식으로 자동 업로드하는 웹을 개발하면 조금 더 편하게 우주에 대한 정보를 얻을 수 있을 것 같다.'라는 생각을 하게 되어 APOD라는 웹을 개발하게 되었습니다.
<br />
<br />

# 📅 개발 기간
2023-03-16 ~ 2023-04-20 (쉬엄쉬엄 개발했습니다. 앞으로 유지보수할 예정)
<br />
<br />

# 💻 기술 스택
## 개발 언어
|<img src="https://user-images.githubusercontent.com/53690235/233387883-f05c0589-3f6e-4e6d-a3e9-ce31ac8deebc.png" width="50" height="50" />|<img src="https://user-images.githubusercontent.com/53690235/233387978-f454625b-6b12-449d-9f78-2efdbf6cf762.png" width="50" height="50" />|
|:---:|:---:|
|C#|Javascript|
## 프론트엔드
|<img src="https://user-images.githubusercontent.com/53690235/233388491-f21ba331-5dd9-41b6-9cf9-1da81ccc0f63.png" width="50" height="50" />|<img src="https://user-images.githubusercontent.com/53690235/233399068-02784351-26df-4724-b3af-b95c7a1a29fb.png" width="50" height="50" />|
|:---:|:---:|
|Bootstrap|razor|
## 백엔드
|<img src="https://user-images.githubusercontent.com/53690235/233393030-60cb263a-3a72-4307-8fd6-a99ffb43523b.png" width="50" height="50" />|
|:---:|
|ASP.NET <br/>Core|
## 데이터베이스
|<img src="https://user-images.githubusercontent.com/53690235/233382541-80335065-eddd-48f0-aef0-78865908f552.png" width="50" height="50" />|<img src="https://user-images.githubusercontent.com/53690235/233384512-ca8bc9ce-9546-4c82-8b5f-ce31d99a7146.png" width="50" height="50" />|
|:---:|:---:|
|MSSQL|Azure SQL <br /> Database|
## 형상관리 툴
|<img src="https://user-images.githubusercontent.com/53690235/233397733-4aebe3b5-2433-43ba-84a2-4aebb7bf0551.png" width="50" height="50" />|
|:---:|
|Git|
<br />
<br />

# 📚 DB 설계
![image](https://user-images.githubusercontent.com/53690235/233400752-4c89945a-0320-47ea-9d45-9fe88caa33e9.png)
<br />
<br />

# 💡 Issues
[InvalidOperationException: The model item passed into the ViewDataDictionary is of type '' ~](https://dong1936.tistory.com/34) <br />
[SqlException: Invalid object name 'APODModel' 오류 해결법](https://dong1936.tistory.com/35) <br />
[Development Mode 설정 오류 / Azure 배포과정](https://dong1936.tistory.com/37) <br />
[댓글 기능 구현](https://dong1936.tistory.com/46) <br />
[댓글 저장 방식에 대한 고찰](https://dong1936.tistory.com/47) <br />
[View와 RedirectToAction 메서드에 대한 고찰](https://dong1936.tistory.com/48) <br />
[여러날짜의 apod 정보를 가져와서 한번에 db에 저장하기 (feat. DB용량 안습)](https://dong1936.tistory.com/49) <br />
[img의 src 속성이 이미지가 아닌 비디오일 경우 iframe의 src 속성으로 비디오를 출력하는 기능 구현](https://dong1936.tistory.com/51) <br />
[게시 후와 게시 전의 DateTime.Now 값이 다른 문제](https://dong1936.tistory.com/52) <br />
<br />
<br />

# 🧑 개발 인원
나 혼자 개발하였다.
