git revert --no-commit 96cfa95908afb4572cd2aad5b93d3eac21e5931d
git mergetool
git commit . -m "take out change 5"
git push

git log
q  to quit 
ctrl + z

git log --graph --pretty


git log --graph --pretty=format:'%Cred%h%Creset -%C(yellow)%d%Creset %s %Cgreen(%cr) %C(bold blue)<%an>%Creset' --abbrev-commit

Stage all changes in <directory> for the next commit.
git add -p

