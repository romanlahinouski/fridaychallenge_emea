export  CORECLR_PROFILER={57e1aa68-2229-41aa-9931-a6e93bbc64d8}
export  CORECLR_ENABLE_PROFILING=1
export  CORECLR_PROFILER_PATH=./libappdprofiler.so


cd /home/centos/Gateway
chmod 777 StartGatewayApi.sh
./StartGatewayApi.sh
cd ..
cd /home/centos/Orderfulfilment
chmod 777 StartOrderfulfilmentApi.sh
./StartOrderfulfilmentApi.sh

