CREATE TABLE "Users" (
    "Id" serial NOT NULL,
    "Role" int DEFAULT 0 NOT NULL,
    "Login" varchar(20) NOT NULL,
    "Nickname" varchar(20) NOT NULL,
    "Password" varchar(64) NOT NULL,
    "CreateDate" timestamp without time zone DEFAULT NOW() NOT NULL,
    CONSTRAINT "PK_users" PRIMARY KEY ("Id")
);

CREATE UNIQUE INDEX "IX_Users_login" ON "Users" ("Login");
