export OUT_DIR=obj
export ROOT_DIR=${PWD}
export TEMPLATE_DIR=${PWD}/content
export PROJECT_NAME=NameYourProject

export TEMPLATE_NAME=loktionov129.web

uninstall:
	dotnet new --debug:reinit && \
	dotnet new -u ${TEMPLATE_NAME}

install:
	dotnet new --install ${TEMPLATE_DIR}/

create:
	rm -rf ${OUT_DIR} && \
	mkdir ${OUT_DIR} && \
	dotnet new ${TEMPLATE_NAME} -n ${PROJECT_NAME} -o ${OUT_DIR} --project_name ${PROJECT_NAME}

pack:
	for var in $$(ls content/src) ; do \
		if [ $$var != ProjectName.sln ]; then \
			rm -rf content/src/$$var/obj; \
			rm -rf content/src/$$var/bin; \
		fi \
	done && \
	rm -rf ./content/src/.vs && \
	rm -rf loktionov129.web.*.nupkg && \
	./nuget pack loktionov129.web.nuspec -Exclude bin/**/*.* -Exclude obj/**/*.* -Exclude .vs/**/*.*